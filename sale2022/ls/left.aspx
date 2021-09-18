
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title></title>
<link rel="StyleSheet" href="css/dtree.css" type="text/css" />
<script type="text/javascript" src="scripts/menu.js"></script>
</head>
<body style="background-color:#FFFFFF;margin:0;">
<script type="text/javascript">

d = new dTree('d');
d.add(0,-1,'&nbsp;管理平台菜单','','pics/daohang.jpg');

d.add(1,0,'&nbsp;发短信','','pics/m_news.gif','pics/m_news.gif');
d.add(10,1,'&nbsp;发短信','send.aspx','pics/send.jpg');
d.add(12,1,'&nbsp;循环发送','loopsend.aspx','pics/send.jpg');
d.add(13,1,'&nbsp;常用短信','common.aspx','pics/edit.jpg');
d.add(14,1,'&nbsp;短信草稿','draft.aspx','pics/edit.jpg');


d.add(1001,0,'&nbsp;订制短信','','pics/m_news.gif','pics/m_news.gif');
d.add(1002,1001,'&nbsp;普通点对点','p2psend.aspx','pics/send.jpg');
d.add(1003,1001,'&nbsp;excel模板1','p2psend_2.aspx','pics/send.jpg');
d.add(1004,1001,'&nbsp;excel模板2','p2psend_3.aspx','pics/send.jpg');


d.add(2,0,'&nbsp;短信管理','','pics/grid.png','pics/grid.png');
d.add(20,2,'&nbsp;待发送','parentdftask.aspx','pics/02780.gif');
d.add(21,2,'&nbsp;正在发送','parentzztask.aspx','pics/02780.gif');
d.add(22,2,'&nbsp;我的已完成','myparenttask.aspx','pics/02780.gif');

d.add(23,2,'&nbsp;循环短信','looptask.aspx','pics/02780.gif');

d.add(3,0,'&nbsp;充值消费','','pics/xiaofei.jpg','pics/xiaofei.jpg');

d.add(32,3,'&nbsp;我的消费记录','voucher.aspx','pics/xiaofeisub.gif');
d.add(33,3,'&nbsp;我的消费统计','vouchermecount.aspx','pics/xiaofeisub.gif');
//d.add(33,3,'&nbsp;在线充值','online.aspx','pics/xiaofeisub.gif');


d.add(4,0,'&nbsp;客户管理','','img/base1.gif','img/base1.gif');

d.add(41, 4, '&nbsp;我的信息', 'myinfo.aspx');
d.add(42,4,'&nbsp;修改密码','pass.aspx');

d.add(99,0,'&nbsp;通讯录','contacts.aspx','pics/qy.png');
				
d.add(6,0,'&nbsp;系统管理','','pics/cog.png','pics/cog.png');
d.add(65,6,'&nbsp;号码分流','sort.aspx');
d.add(64,6,'&nbsp;签名设置','userSign.aspx');
d.add(61,6,'&nbsp;生日提醒','birthday.aspx');
d.add(64,6,'&nbsp;自动回复','autoReply.aspx');
d.add(62,6,'&nbsp;公告管理','news.aspx');
d.add(63,6,'&nbsp;留言/建议/意见','guestbook.aspx');
//d.add(65,6,'&nbsp;群组管理','usergroups.aspx');
document.write(d);	

</script>
</body>
</html>
