// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".editor").trumbowyg({

    
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage','upload'],
            ico:'insertImage'
        }



    },

    btns: [

        ['viewHTML'],
        ['formatting'],
        ['superscript', 'subscript'],
        ['link'],
        ['insertImage'],
        'image',
        'btnGrp-justify',
        'btnGrp-lists',
        ['horizontalRule'],
        ['removeFormat'],
        ['fullscreen']



    ]



});


//$("#rollback").click(function () {

//    location.href = "/index";

    

//});