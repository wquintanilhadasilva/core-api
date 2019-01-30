using coreapi.Model;
using System.Collections.Generic;

namespace coreapi.Mock
{
    /// <summary>
    /// Mock representando o banco de dados do sistema
    /// </summary>
    public class UserDatabase
    {
        /// <summary>
        /// Coleção de usuários
        /// </summary>
        public IDictionary<string, User> Users { get; }

        /// <summary>
        /// Construtor do repositório de usuários
        /// </summary>
        public UserDatabase()
        {
            this.Users = new Dictionary<string, User>();
            this.Users.Add("usuario01", new User { UserID = "usuario01", AccessKey = "94be650011cf412ca906fc335f615cdc" });
            this.Users.Add("usuario02", new User { UserID = "usuario02", AccessKey = "531fd5b19d58438da0fd9afface43b3c" });
        }

        /// <summary>
        /// Obtém um usuário através do seu ID
        /// </summary>
        /// <param name="userID">Chave identificadora do Usuário</param>
        /// <returns>Instância do objeto Usuário caso seja encontrado, do contrário, retorna nulo</returns>
        public User Find(string userID)
        {
            User retorno;
            this.Users.TryGetValue(userID, out retorno);
            return retorno;
        }
    }
}
