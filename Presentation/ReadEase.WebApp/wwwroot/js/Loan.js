$(document).ready(function () {
    //unloanBookList();
});

function unloanBookList() {
    var bookIdSelect = document.getElementById("bookId"); 

    if (bookIdSelect && bookIdSelect.options.length === 0) {
        
        var bookQuery =
        {
            BookStatus: 1,
        }
        
        $.ajax({
            url: "/Book/GetAllBookByStatus",
            type: "POST",
            data: { bookQuery: bookQuery },
        })
        .done(function (result) {
            var jsonResult = JSON.parse(result);
            for (var i = 0; i < jsonResult.length; i++) {
                var option = document.createElement("option");
                option.value = jsonResult[i].id;
                option.text = jsonResult[i].title;
                bookIdSelect.add(option);
            }
        })
        .fail(function (error) {
            console.error("Error: " + error.responseText);
        });
    }
}

function borrowBook() {
    var bookIdSelect = document.getElementById("bookId");
    var borrowerName = document.getElementById("borrowerName");
    var borrowerSurname = document.getElementById("borrowerSurname");
    var contactNumber = document.getElementById("contactNumber");
    var returnDate = document.getElementById("returnDate");
    
    var borrowCommand = {
        BookId: bookIdSelect.value,
        BorrowerName: borrowerName.value,
        BorrowerSurname: borrowerSurname.value,
        ContactNumber: contactNumber.value,
        ReturnDate: returnDate.value
    };

    $.ajax({
        url: "/Loan/BorrowBook",
        type: "POST",
        data: { borrowCommand: borrowCommand },
    })
    .done(function (result) {
        var jsonResult = JSON.parse(result);
        for (var i = 0; i < jsonResult.length; i++) {
            var option = document.createElement("option");
            option.value = jsonResult[i].id;
            option.text = jsonResult[i].title;
            bookIdSelect.add(option);
        }
    })
    .fail(function (error) {
        console.error("Error: " + error.responseText);
    });
}

function searchUnloanBookList() {
    var searchInput = document.getElementById("searchInput");
    var bookIdSelect = document.getElementById("bookId");

    var searchTerm = searchInput.value.toLowerCase();
    // Seçim listesindeki her bir öğeyi kontrol et
    for (var i = 0; i < bookIdSelect.options.length; i++) {
        var optionText = bookIdSelect.options[i].text.toLowerCase();
        var optionValue = bookIdSelect.options[i].value;

        // Arama metni ile eşleşen öğeleri gizle veya göster
        if (optionText.includes(searchTerm)) {
            bookIdSelect.options[i].style.display = "";
        } else {
            bookIdSelect.options[i].style.display = "none";
        }
    }
}
