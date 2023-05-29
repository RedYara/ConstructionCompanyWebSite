using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Diploma.Application.CQRS.Commands.Order.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMailSender _mailSender;
        public ChangeOrderStatusCommandHandler(IDiplomaDbContext dbContext, IMailSender mailSender)
        {
            _dbContext = dbContext;
            _mailSender = mailSender;
        }
        public async Task<bool> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            switch (request.Value)
            {
                case "В обработке":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ находится в обработке, ожидайте обратной связи.");
                    break;
                case "Выполнен":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ выполнен, ждём вас снова!");
                    break;
                case "Отклонен":
                    await _mailSender.SendEmailAsync(order.Email, $"Информация по заказу #{order.Id}", $"Ваш заказ отклонен, для уточнения подробностей Вы можете связаться с нами по телефону.");
                    break;
                default:
                    break;
            }
            order.Status = request.Value;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
