
$(document).ready(function () {
    $('#userTree').jstree({
        'core': {
            'data': {
                'url': 'AuthorisationTree/GetTree',
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    });

});