partial class Program
{
    static void QueryingCategories()
    {
        /*using (EventPlanning db = new())
        {
            SectionTitle("Events and how many organizers they have:");
            // a query to get all categories and their related products
            IQueryable<Event>? categories = db.Events?
            .Include(c => c.organizer);
            if ((categories is null) || (!categories.Any()))
            {
                Fail("No categories found.");
                return;
            }
            // execute query and enumerate results
            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count}products.");
            }
        }*/
    }
}
    

