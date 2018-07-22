(function () {
    $(function () {

        var _campaignService = abp.services.app.campaign;
        var _$modal = $('#CampaignCreateModal');
        var _$form = _$modal.find('form');
        var baseurl = 'http://112.74.32.7:81/api/services/app';
        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshCampaignList();
        });

        $('.delete-campaign').click(function () {
            var campaignId = $(this).attr("data-campaign-id");
            var Name = $(this).attr('data-campaign-name');

            deleteCampaign(campaignId, Name);
        });

        //明细
        $('.campaign-item').click(function (e) {
            var campaignId = $(this).attr("data-campaign-id");
            
            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Campaign/GetCampaignItemModal?Id=' + campaignId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#CampaignItemModal div.modal-content').html(content);
                    $('#CampaignItemGrid').kendoGrid({
                        editable: true,
                        columns: [{
                            field: 'productName',
                            title: 'productName'
                        }, {
                            field: 'price',
                            title: 'price'
                        }],
                        dataSource: new kendo.data.DataSource({
                            autoSync: true,
                            transport: {
                                read: function (options) {
                                    $.ajax({
                                        url: baseurl + '/Campaign/GetCampaignByIdAsync?Id=' + campaignId,
                                        type: 'GET',
                                        contentType: 'application/html',
                                        success: function (content) {
                                            options.success(content.result.campaignItem);
                                        },
                                        error: function (e) { options.error(e); }
                                    });
                                    //abp.services.app.campaign.getCampaignById(JSON.stringify({}))
                                    //    .done(function (result) {
                                    //        options.success(result.campaignItem);
                                    //    })
                                    //    .fail(function (error) {
                                    //        options.error(error);
                                    //    });
                                },
                                update: function (options) {
                                    abp.services.app.user.update(options.data)
                                        .done(function (result) {
                                            options.success(null);
                                        })
                                        .fail(function (error) {
                                            options.error(error);
                                        });
                                }
                            },
                            schema: {
                                model: {
                                    id: 'id',
                                    fields: {
                                        id: {
                                            editable: false,
                                            nullable: true
                                        },
                                        userName: {
                                            editable: true
                                        },
                                        name: {
                                            editable: true
                                        },
                                        surname: {
                                            editable: true
                                        },
                                        emailAddress: {
                                            editable: true
                                        },
                                        isActive: {
                                            editable: false
                                        }
                                    }
                                }
                            }
                        })
                    });
                },
                error: function (e) { }
            });
        });

        //编辑
        $('.edit-campaign').click(function (e) {
            var campaignId = $(this).attr("data-campaign-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Campaign/EditCampaignModal?Id=' + campaignId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#CampaignEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        //添加
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            //验证
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
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCampaignList() {
            location.reload(true); //reload page to see new campaign!
        }

        function deleteCampaign(campaignId, Name) {
            abp.message.confirm(
                "确定删除 '" + Name + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        //var data = { id: Number(campaignId) };
                        _campaignService.deteleCampaign({ id: Number(campaignId) }).done(function () {
                            refreshCampaignList();
                        });
                    }
                }
            );
        }
    });
})();