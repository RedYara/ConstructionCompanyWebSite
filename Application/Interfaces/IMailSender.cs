namespace Application.Interfaces
{
    public interface IMailSender
    {
        /// <summary>
        /// Отправка сообщения на почту
        /// </summary>
        /// <param name="emailTo">Адресат</param>
        /// <param name="subject">Тема</param>
        /// <param name="body">Сообщение</param>
        /// <returns></returns>
        Task SendEmailAsync(string emailTo, string subject, string body);
    }
}
