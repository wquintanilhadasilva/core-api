﻿using coreapi.Jwt;
using coreapi.Mock;
using coreapi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace coreapi.Controllers
{
    /// <summary>
    /// Operações de autenticação
    /// </summary>
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        /// <summary>
        /// Efetua o login no sistema
        /// </summary>
        /// <param name="usuario">Referência do Usuário que deseja autenticar-se, enviado no Payload</param>
        /// <param name="usersDAO">Referência do repositório de usuários, injetado pelo container</param>
        /// <param name="signingConfigurations">Configurações de Algoritmos para geração do token pelo JWT</param>
        /// <param name="tokenConfigurations">Parâmetros de Geração do Token JWT</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public object Post(
               [FromBody]User usuario,
               [FromServices]UserDatabase usersDAO,
               [FromServices]SigningConfigurations signingConfigurations,
               [FromServices]TokenConfigurations tokenConfigurations)
        {

            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UserID))
            {
                var usuarioBase = usersDAO.Find(usuario.UserID);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.UserID == usuarioBase.UserID &&
                    usuario.AccessKey == usuarioBase.AccessKey);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}
