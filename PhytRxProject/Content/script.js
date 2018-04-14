.(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
var fsClient = filestack.init('A2SRemgNRSCQt4ifZoCbUz'); //api key
function openPicker() {
    fsClient.pick({
        accept: ['image/*'],
        minFiles: 1,
        maxFiles: 1,
        maxSize: (100 * 1024 * 1024)
    }).then(function (response) {
        console.log(response);
        $('#exPhoto').attr("value", response.filesUploaded[0].url);
        var permImage = response.filesUploaded[0].url;
    });
}


Add CommentCollapse 