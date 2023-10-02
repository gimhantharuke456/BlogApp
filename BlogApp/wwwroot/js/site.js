function YourKnockoutViewModel() {
  var self = this;

  // Observable array to store categories
  self.categories = ko.observableArray([]);

  // Function to retrieve categories from the server
  self.loadCategories = function () {
    $.ajax({
      url: "/Category/GetCategories", // Update with your actual endpoint
      type: "GET",
      success: function (data) {
        self.categories(data);
      },
    });
  };

  // Function to add a new category
  self.addCategory = function () {
    var newCategory = { Name: "New Category" }; // You can customize this
    $.ajax({
      url: "/Category/AddCategory",
      type: "POST",
      contentType: "application/json",
      data: JSON.stringify(newCategory),
      success: function (data) {
        self.categories.push(data); // Add the new category to the observable array
      },
    });
  };

  // Function to update a category
  self.updateCategory = function (category) {
    $.ajax({
      url: "/Category/UpdateCategory",
      type: "POST",
      contentType: "application/json",
      data: JSON.stringify(category),
      success: function () {
        // Update the category on the client side if needed
      },
    });
  };

  // Function to delete a category
  self.deleteCategory = function (category) {
    $.ajax({
      url: "/Category/DeleteCategory/" + category.Id,
      type: "DELETE",
      success: function () {
        self.categories.remove(category); // Remove the category from the observable array
      },
    });
  };

  // Load categories when the ViewModel is created
  self.loadCategories();
}

var viewModel = new YourKnockoutViewModel();
ko.applyBindings(viewModel);
