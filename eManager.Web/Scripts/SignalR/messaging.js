$(function () {
    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.messagingHub;
    // Create a function that the hub can call back to display messages.
    chat.client.addMessageToPage = function (message) {
        // Add the message to the page.
        $('#discussion').append('<div class="alert alert-danger alert-dismissible"' +
            'role="alert"><button type="button" class="close" data-dismiss="alert"' +
            'aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
            '<strong>Administrator</strong>: ' + htmlEncode(message) + '</div>');
    };
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
