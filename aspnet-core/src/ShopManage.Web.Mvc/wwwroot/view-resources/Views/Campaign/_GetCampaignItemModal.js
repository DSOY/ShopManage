(function ($) {

    var _campaignService = abp.services.app.campaign;
    var _$modal = $('#CampaignItemModal');
    var _$form = $('form[name=CampaignItemForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var dto = _$form.serializeFormToObject(); //序列化表单对象

        abp.ui.setBusy(_$modal);//避免重复提交
        //约定大于配置
        _campaignService.createOrUpdateCampaign(dto).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see new campaign!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
    
})(jQuery);