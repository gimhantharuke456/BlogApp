// DeleteViewModel.js

function DeleteViewModel() {
  var self = this;
  self.items = ko.observableArray([]);

  // Function to handle item deletion
  self.deleteItem = function (item) {
    $.ajax({
      url: "/Item/Delete", // Replace 'Item' with your actual controller name
      type: "POST",
      data: { itemId: item.id },
      success: function () {
        self.items.remove(item);
      },
      error: function (error) {
        console.log("Error deleting item:", error);
      },
    });
  };
}

var deleteViewModel = new DeleteViewModel();
ko.applyBindings(deleteViewModel, document.getElementById("delete-container")); // Replace 'delete-container' with the ID of your container element
