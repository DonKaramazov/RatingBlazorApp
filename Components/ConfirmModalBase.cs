using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class ConfirmModalBase : ComponentBase
    {
        protected bool ShowConfirmation { get; private set; }

        [Parameter]
        public string Title { get; set; } = "Confirmer la suppression";

        [Parameter]
        public string Message { get; set; } = "Etes vous sur du vouloir supprimer l'élément ?";

        [Parameter]
        public string CancelButton { get; set; } = "Annuler";

        [Parameter]
        public string ConfirmButton { get; set; } = "Confirmer";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }


        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }


    }
}
