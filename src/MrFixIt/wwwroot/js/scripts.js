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
    $('.show-claim-page').click(function () {
        console.log(this.id);
        var route = '#claim-result-' + this.id;
        //console.log(route);
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Jobs/Claim/' + this.id,
            success: function (result) {
                $(route).html(result);
            }
        });
    });

    $('.job-activate').click(function (event) {
        var jobId = this.value;
        console.log(this);
        console.log(jobId);
        $.ajax({
            url: '/Jobs/Activate/' + jobId,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                $('.activate-result').html('<p>' + result.title + '</p>');
            }
        });
    });

    $('.job-complete').click(function (event) {
        var jobId = this.value;
        console.log(this);
        console.log(jobId);
        $.ajax({
            url: '/Jobs/Complete/' + jobId,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                $('.complete-result').html('<p>You just marked <em>' + result.title + '</em> as complete</p>');
                $('.worker-available').html('<h2>You don\'t have any activated jobs. Please <a href="/Jobs">select a job</a></h2>');
            }
        });
    });

    //$('.complete-job').submit(function (event) {
    //    event.preventDefault();
    //    console.log("it is reaching the ajax for complete");
    //    var newJob = {};
    //    var jobProperties = $('.claim-job').serializeArray();
    //    newJob.JobId = jobProperties[0].value;
    //    newJob.Title = jobProperties[1].value;
    //    newJob.Description = jobProperties[2].value;
    //    newJob.Completed = job.jobProperties[3].value;
    //    $.ajax({
    //        type: 'POST',
    //        url: $(this).data('url-action'),
    //        datatype: 'json',
    //        data: newJob,
    //        success: function (success) {
    //            console.log("complete worked");
    //        }
    //    });
    //});
})