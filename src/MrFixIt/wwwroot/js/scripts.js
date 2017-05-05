$(document).ready(function () {
    $('.claim-job').submit(function (event) {
        event.preventDefault();
        console.log("it is reaching the ajax");
        var newJob = {};
        var jobProperties = $('.claim-job').serializeArray();
        newJob.JobId = jobProperties[0].value;
        newJob.Title = jobProperties[1].value;
        newJob.Description = jobProperties[2].value;
        $.ajax({
            type: 'POST',
            url: $(this).data('url-action'),
            datatype: 'json',
            data: newJob,
            success: function (success) {
                console.log("it worked");
            }
        });
    });
})