(function () {
    $(function () {

        var _categoryService = abp.services.app.category;
        var _$modal = $('#CategoryCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshCategoryList();
        });

        $('.delete-category').click(function () {
            var categoryId = $(this).attr("data-category-id");
            var Name = $(this).attr('data-category-name');

            deleteCategory(categoryId, Name);
        });

        $('.edit-category').click(function (e) {
            var categoryId = $(this).attr("data-category-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Category/EditCategoryModal?categoryId=' + categoryId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#CategoryEditModal div.modal-content').html(content);
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
            _categoryService.createOrUpdateCategory(dto).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new category!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCategoryList() {
            location.reload(true); //reload page to see new category!
        }

        function deleteCategory(categoryId, Name) {
            abp.message.confirm(
                "确定删除 '" + Name + "'?",
                function (isConfirmed) {
                    if (isConfirmed) {
                        var data = { id: Number(categoryId) };
                        _categoryService.deteleCategoryAsync(data).done(function () {
                            refreshCategoryList();
                        });
                    }
                }
            );
        }
    });
})();