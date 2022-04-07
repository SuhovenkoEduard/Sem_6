$('#logout').submit(function (e) {
    $.ajax({
        type:"Post",
        url:"/login/logout"
    })
})
$('#signIn').submit(function (e) {
    
    $.ajax({
        type:"Post",
        data:$(this).serialize(),
        url:"/login/signin"
    })
})
$('#Reg').submit(function (e) {
    $.ajax({
        type:"Post",
        data:$(this).serialize(),
        url:"/register/adduser"
    })
})
// $("#addr").click(function() {
//     $.ajax({
//         type: "GET",
//         url: "/Address",
//         success : function(data) {
//             $("#rootAddrr").html(data);
//         }
//     });
// });
$("#stud1").mouseenter(function () {
    $(".stud").css("display","block")
}).mouseleave(function () {
    $(".stud").css("display","none")
})