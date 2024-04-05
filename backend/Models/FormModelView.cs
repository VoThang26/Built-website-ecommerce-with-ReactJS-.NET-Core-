namespace vohoangthang.Exercise02.Models
{
    public class FormAttributeView
    {
        public string attribute_name { get; set; }

    }
    public class FormAttributeValueView
    {
        public Guid attribute_id { get; set; }
        public string? attribute_value { get; set; }
        public string? color { get; set; }
    }

    public class FormCategoryView
    {
        public Guid? parent_id { get; set; }
        public string? category_name { get; set; }
        public string? category_description { get; set; }
        public string? icon { get; set; }
        public string? image { get; set; }
        public bool active { get; set; }
    }

    public class FormProductView
    {
        public string? product_name { get; set; }
        public string? SKU { get; set; }
        public double regular_price { get; set; }
        public double discount_price { get; set; }
        public int quantity { get; set; }
        public string? short_description { get; set; }
        public string? product_description { get; set; }
        public double product_weight { get; set; }
        public string? product_note { get; set; }
        public bool published { get; set; }
    }

    public class FormOrderStatusView
    {
        public string? status_name { get; set; }
        public string? color { get; set; }
        public string? privacy { get; set; }
    }

    public class FormRoleView
    {
        public string? role_name { get; set; }
        public string? privileges { get; set; }
    }

    public class FormTagView
    {
        public string? tag_name { get; set; }
        public string? icon { get; set; }
    }
}