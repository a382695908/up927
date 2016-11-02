
(
//判断用户是否已登录
function() {
    var ul_login = $('#ul_login');
    var ul_userinfo = $('#ul_userinfo');
    var a_username = $('#a_username');
    var a_logout = $('#a_logout');
    var a_login = $('#a_login');
    var a_register = $('#a_register');

    $.ajax({
        url: '/ajax/ajax_m.aspx?get=7',
        anysn: true
    }).success(function(r) {
        var obj = JSON.parse(r);
        var username = obj.username;
        if (username != '') {
            a_username.html(username);
            ul_userinfo.css('display', 'inline-block');
            ul_login.css('display', 'none');

            //绑定退出登录事件
            a_logout.on('click', function() {
                $.ajax({
                    url: '/ajax/ajax_m.aspx?get=8',
                    anysn: true
                }).success(function(r) {
                    a_username.html('');
                    ul_userinfo.css('display', 'none');
                    ul_login.css('display', 'inline-block');

                    a_login.on('click', function() {
                        winpop.init({
                            type: 2,
                            width: 410,
                            height: 310,
                            content: '/login.html'
                        })
                    })
                }).error(function(e) {
                    console.log(e);
                })
            })
        }
        else {
            ul_userinfo.css('display', 'none');
            ul_login.css('display', 'inline-block');

            //绑定显示登录弹出层事件
            a_login.on('click', function() {
                winpop.init({
                    type: 2,
                    width: 410,
                    height: 310,
                    content: '/login.html'
                })
            })

//            a_register.on('click', function() {
//                winpop.init({
//                    type: 2,
//                    width: 760,
//                    height: 350,
//                    content: '/register.html'
//                })
//            })

        }
    }).error(function(e) {
        console.log(e);
    })
}
)()