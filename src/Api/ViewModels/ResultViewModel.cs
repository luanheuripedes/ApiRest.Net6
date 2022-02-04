namespace Api.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; } //dynamic funciona como var, ele se torna o tipo que voce mandar pra ele
    }
}
