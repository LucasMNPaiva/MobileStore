
$("input[name='phone']").inputmask({
    mask: ['(99) 9999-9999', '(99) 99999-9999'],
    keepStatic: true
});

function NewPassword() {
    let data = {
        email: '',
        password:''
    }
    $.ajax({
        url: 'https://localhost:44317/api/Login/NewPassword',
        type: 'POST',
        data: data,
        success: function () {
            alert('Uma nova senha foi encaminhada para seu Email')
            window.location.href = "https://localhost:44317/Home/home"
        }
    })
}