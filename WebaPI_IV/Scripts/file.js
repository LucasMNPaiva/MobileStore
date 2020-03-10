
    function createUser(){
            var user={
        username : $('#username').val(),
    password : $('#password').val(),
    email : $('#email').val()
    } ;
            $.ajax({
        type:'POST',
    url:'https://localhost:44317/api/User',
    data:JSON.stringify(user) ,
    contentType:"application/json",
                success:function(data){
        console.log(data),
        console.log(username.val)
    },
})
}


function DeleteUser() {
    let id = $('#IdDelete').val();

    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44317/api/User/' + id,

    })
}

        function UpdateUser(){
                var user={

            username: $('#userUpdate').val(),
        password: $('#passwordUpdate').val(),
        email:$('emailUpdate').val()
    }
                $.ajax({
            type:'PUT',
        url:'https://localhost:44317/api/User/'+$('#idUpdate').val(),
        data:user

    })
}



        function CreateProduct(){

           var files = $('#fileUpload').get(0).files;
        var formData = new FormData();
           for(var i=0;i<files.length; i++){
            formData.append(files[i].name, files[i])
        }
        formData.append("Name",$('#productName').val());
        formData.append("Price",$('#productPrice').val());

                $.ajax({
            method:'POST',
        url:'https://localhost:44317/api/Product/CreateProduct',
        data:formData,
        processData:false,
        contentType:false,
                    success:function(data){
            console.log('success uploaded')
        },
                    error:function(data){
            console.log('upload failed')
        }
        })

}
