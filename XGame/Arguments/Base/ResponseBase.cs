namespace XGame.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = XGame.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public string Message { get; set; }
    }
}
