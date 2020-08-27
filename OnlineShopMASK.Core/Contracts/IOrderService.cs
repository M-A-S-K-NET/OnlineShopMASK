using OnlineShopMASK.Core.Models;
using OnlineShopMASK.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMASK.Core.Contracts
{
    //Create the interface
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
        void UpdateOrder(Order updatedOrder);
        List<Order> GetOrderList();
        Order GetOrder(string id);
    }
}