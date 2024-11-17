namespace ElectriXDriveUI.Models
{
    public class ErrorViewModel
    {
        // ID da requisi��o - usado para identificar e rastrear erros espec�ficos.
        public string? RequestId { get; set; }

        // Propriedade que indica se o RequestId deve ser exibido.
        // Retorna verdadeiro se RequestId n�o for nulo ou vazio, ajudando na exibi��o de informa��es de depura��o.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
