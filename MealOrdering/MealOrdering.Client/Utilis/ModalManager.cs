﻿using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.CustomComponents.ModalComponents;

namespace MealOrdering.Client.Utilis
{
    public class ModalManager
    {
        private readonly IModalService _modalService;

        public ModalManager(IModalService modalService )
        {
            _modalService = modalService;
        }

        public async Task ShowMessageAsync(String Title, String Message, int Duration = 0)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = _modalService.Show<ShowMessagePopupComponent>(Title, mParams);

            if(Duration > 0)
            {
                await Task.Delay(Duration);
                modalRef.Close();
            }
        }

        public async Task<bool> ConfirmationAsync(String Title, String Message)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = _modalService.Show<ConfirmationPopupComponent>(Title, mParams);
            var modalResult = await modalRef.Result;

            return !modalResult.Cancelled; //which one is active? Cancel or Ok or Yes?

        }

    }
}
