namespace EntityHelper
{
    public class ResultFromProcedure
    {
        #region Properties

        public bool EmptyResult { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
        public bool WrongParameter { get; set; }
        public string Xml { get; set; }

        #endregion Properties
    }
}