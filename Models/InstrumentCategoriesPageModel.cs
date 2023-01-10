using Microsoft.AspNetCore.Mvc.RazorPages;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Migrations;

namespace Inchiriere_Instrumente.Models
{
    public class InstrumentCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Inchiriere_InstrumenteContext context, Instrument instrument)
        {
            var allCategories = context.Category;
            var instrumentCategories = new HashSet<int>(
            instrument.InstrumentCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = instrumentCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateInstrumentCategories(Inchiriere_InstrumenteContext context,
        string[] selectedCategories, Instrument instrumentToUpdate)
        {
            if (selectedCategories == null)
            {
                instrumentToUpdate.InstrumentCategories = new List<InstrumentCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var instrumentCategories = new HashSet<int>
                (instrumentToUpdate.InstrumentCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!instrumentCategories.Contains(cat.ID))
                    {
                        instrumentToUpdate.InstrumentCategories.Add(
                        new InstrumentCategory
                        {
                            InstrumentID = instrumentToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (instrumentCategories.Contains(cat.ID))
                    {
                        InstrumentCategory courseToRemove
                        = instrumentToUpdate
                        .InstrumentCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
