var sorgu = new Array();

$('#input1').on('change', function () {
    var deger = $('#input1').val();
    if (deger!=null) {
        sorgu.push({
            'Key': 'Name',
            'Value': $('#input1').val(),
            'Query': $('#sorguSecimi1').val()
        });
    }

});

$('#input2').on('change', function () {
    var deger = $('#input2').val();
    if (deger != null) {
        sorgu.push({
            'Key': 'Qty',
            'Value': $('#input2').val(),
            'Query': $('#sorguSecimi2').val()
        });
    }

});

$('#sorguSecimi1').on('change', function () {
    var deger = $('#sorguSecimi1').val();
    if (deger != null) {
        sorgu.find(x => x.Key == 'Name').Query = $('#sorguSecimi1').val();
    }

});

$('#sorguSecimi2').on('change', function () {
    var deger = $('#sorguSecimi2').val();
    if (deger != null) {
        sorgu.find(x => x.Key == 'Qty').Query = $('#sorguSecimi2').val();
    }

});

$('#gonder').on('click', function () {
    console.log(JSON.stringify(sorgu));
    $.ajax({
        url: 'home/test',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(sorgu)
    }).done(function (data) {
        console.log(data);
    }).fail(function (err) {
        console.log(err);
    });
});
//$(() => {

//})