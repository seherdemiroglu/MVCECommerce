namespace MVCECommerce.Domain
{
    public class Specification : _EntityBase
    {
        #region Scalar
        public string? NameTr { get; set; }
        public string? NameEn { get; set; }
        public Guid CategoryId { get; set; }
        #endregion

        #region Navigation
        public Category? Category { get; set; }

        #endregion
    }
}
