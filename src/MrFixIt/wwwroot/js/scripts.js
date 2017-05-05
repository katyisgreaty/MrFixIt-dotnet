$(document).ready(function () {
    $('.claim-job').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            url: '/Jobs',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var claimedJob = result.title;
                var jobId = result.id.toString();
                $('#claim-result').text(claimedJob);
            }
        });
    });
})