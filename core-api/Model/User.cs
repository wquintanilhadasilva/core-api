namespace coreapi.Model
{
    /// <summary>
    /// Representa um usuário da aplicação
    /// </summary>
    public class User
    {
        /// <summary>
        /// Chave identificadora do usuário
        /// </summary>
        public string UserID {get; set;}

        /// <summary>
        /// Senha de identificação do usuário
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Compara outra referência com esta aqui pelo valor UserID
        /// </summary>
        /// <param name="obj">Outra referência a ser usada na comparação</param>
        /// <returns>True caso seja o mesmo Type e o valor UserID idêntico ou False caso contrário</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(User))
            {
                return false;
            }

            return (obj as User).UserID.Equals(this.UserID);
        }

        /// <summary>
        /// Ajusta o HashCode para considerar apenas o UserID
        /// </summary>
        /// <returns>Valor HashCode do UserID</returns>
        public override int GetHashCode()
        {
            return this.UserID.GetHashCode();
        }
    }
}
