﻿using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);
    }
}
