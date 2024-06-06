namespace MaterialsExchange.Models
{
	public static class MaterialsExchangeRepository
	{
		public static List<Material> Materials { get; set; } = new List<Material>(){
			new Material
			{
				Id = 1,
				Name = "Material One",
				Price = 1,
				SellerId = 1,
			},
			new Material
			{
				Id = 2,
				Name = "Material Two",
				Price = 2,
				SellerId = 2,
			},
		};

		public static List<Seller> Sellers { get; set; } = new List<Seller>(){
			new Seller
			{
				Id = 1,
				Name = "Seller One",
			},
			new Seller
			{
				Id = 2,
				Name = "Seller Two",
			},
		};
	}
}
