$(document).ready(function () {
    getBookList();
});

function getBookList() {
    var bookListContainer = document.getElementById("bookList");

    if (bookListContainer != null) {

        bookListContainer.innerHTML = "";

        var bookQuery =
        {
            PageNumber: 1,
            PageSize: 10,
            Search: ""
        }

        $.ajax({
            url: "/Book/GetBookList",
            type: "POST",
            data: { bookQuery: bookQuery },
        })
        .done(function (result) {
            //debugger;
            var jsonResult = JSON.parse(result);
            showBooks(bookListContainer,jsonResult.datas);
        })
        .fail(function (error) {
            console.error("Error: " + error.responseText);
        });
    }
}

function showBooks(bookListContainer,books) {
    debugger;

    bookListContainer.innerHTML = "";

    if (books) {
        books.forEach(function (book) {
            debugger;
            var bookDiv = document.createElement("div");
            bookDiv.className = "card mb-1 vertical-card text-center"; // text-center sınıfı ile içeriği ortala
            bookDiv.innerHTML = `
                        <img src="${book.imageURL}" class="card-img-top card-image" alt="${book.title}">
                        <div class="card-body card-details">
                            <p class="card-text">
                                <strong>${book.title}</strong> -
                                <small class="text-muted">${book.author}</small> -
                                <span class="badge ${book.status === 1 ? 'bg-success' : 'bg-danger'}">${book.status === 1 ? 'Available' : 'Loan'}</span>
                                ${book.returnDate ? `<strong>${formatDate(book.returnDate)}</strong>` : ''}
                            </p>
                            <p class="card-text">${book.description}</p>
                        </div>
                    `;
            bookListContainer.appendChild(bookDiv);
        });
    }
}

function formatDate(dateString) {
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const formattedDate = new Date(dateString).toLocaleDateString(undefined, options);
    return formattedDate;
}

function getAllBookGenre() {
    var selectElement = document.getElementById('bookGenreId');
    
    if (selectElement.options.length === 0) {
        $.ajax({
            url: "/Book/GetBookGenreList",
            type: "POST",
        })
        .done(function (result) {
            //debugger;
            var jsonResult = JSON.parse(result);

            for (var i = 0; i < jsonResult.length; i++) {
                var option = document.createElement('option');
                option.value = jsonResult[i].id;  
                option.text = jsonResult[i].genreName; 
                selectElement.appendChild(option);
            }
        })
        .fail(function (error) {
            console.error("Error: " + error.responseText);
        });
    }
}

function addBook() {
    debugger;
    var book = {
        title: document.getElementById('title').value,
        author: document.getElementById('author').value,
        description: document.getElementById('description').value,
        bookGenreId: document.getElementById('bookGenreId').value,
        ISBN: document.getElementById('isbn').value,
        imageUrl: document.getElementById('imageUrl').value,
    };
    
    if (book.title === '' && book.author === '' && book.description === '' && book.bookGenreId === '' && book.isbn === '' && book.imageUrl === '' &&
        book.title === null && book.author === null && book.description === null && book.bookGenreId === null && book.isbn === null && book.imageUrl === null) {
        alert("Tüm alanları doldurunuz.");
        return;
    } 
    
    $.ajax({
        url: "/Book/AddBook",
        type: "POST",
        data: { book: book },
    })
    .done(function (result) {
        debugger;
        var jsonResult = JSON.parse(result);
            
    })
    .fail(function (error) {
        debugger;
    console.error("Error: " + error.responseText);
    });
}