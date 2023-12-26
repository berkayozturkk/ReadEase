$(document).ready(function () {

    //$("#layoutId").attr("hidden", false);

    initPage();
});

function initPage() {
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
                debugger;
                var jsonResult = JSON.parse(result);
                showBooks(bookListContainer,jsonResult.datas);
            })
            .fail(function (error) {
                console.error("Error: " + error.responseText);
            });

        
    }

    //var bookQuery =
    //{
    //    PageNumber: 1,
    //    PageSize: 10,
    //    Search: ""
    //}

    //$.ajax({
    //    url: "/Book/GetBookList",
    //    type: "POST",
    //    data: { bookQuery: bookQuery },
    //    })
    //    .done(function (result) {
    //        debugger;
    //        var jsonResult = JSON.parse(result);
    //        showBooks(jsonResult.datas);
    //    })
    //    .fail(function (error) {
    //        console.error("Error: " + error.responseText);
    //    });

        //var books = [
        //{
        //    Title: "Clean Code",
        //    Author: "Robert C. Martin",
        //    Description: "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship . ",
        //    ImageURL: "https://m.media-amazon.com/images/I/51E2055ZGUL._SY466_.jpg",
        //    ISBN: "12345678945",
        //    Status: "Available"
        //},

        //{
        //    Title: "The Pragmatic Programmer",
        //    Author: "Andrew Hunt, David Thomas",
        //    Description: "Hayatımdaki en önemli kitaplardan biri. Obie Fernandez, Yazar, The Rails Way Yirmi yıl önce, The Pragmatic Programmer'ın ilk baskısı kariyerimin gidişatını tamamen değiştirdi. Bu yeni baskı sizinki için de aynısını yapabilir.―Mike Cohn, Çevik Tahmin ve Planlama ile Başarılı Olmanın Yazarı ve Uygulamalı Kullanıcı Hikayeleri",
        //    ImageURL: "https://m.media-amazon.com/images/I/51IA4hT6jrL._SY445_SX342_.jpg",
        //    ISBN: "12345678945",
        //    Status: "OnLoan"
        //},
        //{
        //    Title: "Design Patterns: Elements of Reusable Object-Oriented Software",
        //    Author: "Richard Helm , Ralph Johnson , John Vlissides",
        //    Description: "Capturing a wealth of experience about the design of object-oriented software, four top-notch designers present a catalog of simple and succinct solutions to commonly occurring design problems. Previously undocumented, these 23 patterns allow designers to create more flexible, elegant, and ultimately reusable designs without having to rediscover the design solutions themselves.",
        //    ImageURL: "https://m.media-amazon.com/images/I/81gtKoapHFL._SY466_.jpg",
        //    ISBN: "12345678945",
        //    Status: "Available"
        //},
        //];

    /*showBooks(books);*/
}

function showBooks(bookListContainer,books) {
    debugger;

    bookListContainer.innerHTML = "";

    if (books) {
        books.forEach(function (book) {
            var bookDiv = document.createElement("div");
            bookDiv.className = "card mb-1 vertical-card text-center"; // text-center sınıfı ile içeriği ortala
            bookDiv.innerHTML = `
                <img src="${book.imageURL}" class="card-img-top card-image" alt="${book.title}">
                <div class="card-body card-details">
                    <p class="card-text">
                        <strong>${book.title}</strong> -
                        <small class="text-muted">${book.author}</small> -
                            <span class="badge ${book.status === 1 ? 'bg-success' : 'bg-danger'}">${book.status === 1 ? 'Available' : 'Loan'}</span>
                    </p>
                    <p class="card-text">${book.description}</p>
                </div>
            `;
            bookListContainer.appendChild(bookDiv);
        });
    }
}