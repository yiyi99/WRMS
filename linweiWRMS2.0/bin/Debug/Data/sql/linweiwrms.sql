/*
MySQL Backup
Source Server Version: 5.6.28
Source Database: linweiwrms
Date: 2016/7/20 16:21:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
--  Table structure for `file`
-- ----------------------------
DROP TABLE IF EXISTS `file`;
CREATE TABLE `file` (
  `f_id` int(4) unsigned NOT NULL AUTO_INCREMENT COMMENT '文件id',
  `p_id` tinyint(2) unsigned NOT NULL COMMENT '属于哪个项目（project）',
  `f_name` varchar(50) NOT NULL COMMENT '文件名（项目名）',
  `f_town` varchar(60) NOT NULL COMMENT '辖区村镇',
  `f_no` varchar(40) NOT NULL COMMENT '项目文件编号',
  `f_location` varchar(60) NOT NULL COMMENT '地理位置',
  `f_dong` int(3) NOT NULL COMMENT '东经',
  `f_bei` int(3) NOT NULL COMMENT '北纬',
  `f_buildtime` char(10) NOT NULL COMMENT '建设日期',
  `f_value` float(12,2) unsigned NOT NULL COMMENT '工程固定原值',
  `f_maketype` varchar(20) NOT NULL COMMENT '产权类型',
  `f_makeperson` varchar(30) NOT NULL COMMENT '产权人',
  `f_guanhutype` varchar(20) NOT NULL COMMENT '管护类型',
  `f_guanhuperson` varchar(30) NOT NULL COMMENT '管护人',
  `f_uptime` char(10) NOT NULL,
  PRIMARY KEY (`f_id`),
  KEY `fk_file_pid` (`p_id`),
  CONSTRAINT `fk_file_pid` FOREIGN KEY (`p_id`) REFERENCES `project` (`p_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `picture`
-- ----------------------------
DROP TABLE IF EXISTS `picture`;
CREATE TABLE `picture` (
  `pic_id` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `f_id` int(4) unsigned NOT NULL,
  `pic_name` char(40) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`pic_id`),
  KEY `fk_picture` (`f_id`),
  CONSTRAINT `fk_picture` FOREIGN KEY (`f_id`) REFERENCES `file` (`f_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `project`
-- ----------------------------
DROP TABLE IF EXISTS `project`;
CREATE TABLE `project` (
  `p_id` tinyint(2) unsigned NOT NULL AUTO_INCREMENT COMMENT '项目id',
  `p_name` varchar(20) NOT NULL COMMENT '项目名',
  `p_path` varchar(50) NOT NULL COMMENT '项目路径',
  PRIMARY KEY (`p_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `temp`
-- ----------------------------
DROP TABLE IF EXISTS `temp`;
CREATE TABLE `temp` (
  `t_id` tinyint(2) unsigned NOT NULL AUTO_INCREMENT COMMENT '模板id',
  `t_name` varchar(20) NOT NULL COMMENT '模板名',
  `p_id` tinyint(2) unsigned NOT NULL COMMENT '属于哪个项目',
  PRIMARY KEY (`t_id`),
  KEY `fk_temp_pid` (`p_id`),
  CONSTRAINT `fk_temp_pid` FOREIGN KEY (`p_id`) REFERENCES `project` (`p_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `u_id` tinyint(3) unsigned NOT NULL AUTO_INCREMENT COMMENT '用户id',
  `u_name` char(20) NOT NULL DEFAULT '' COMMENT '用户名',
  `u_pwd` char(20) NOT NULL COMMENT '用户密码',
  `md5_pwd` char(32) NOT NULL COMMENT '管理员登陆密码',
  PRIMARY KEY (`u_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
--  Records 
-- ----------------------------
INSERT INTO `project` VALUES ('1','抽水站','./Data/project/001/'), ('2','地下水监测站','./Data/project/002/'), ('3','机电井','./Data/project/003/'), ('4','集中供水1000方以上','./Data/project/004/'), ('5','集中供水1000方以下','./Data/project/005/'), ('6','末级渠道','./Data/project/006/'), ('7','中小河流提防','./Data/project/007/'), ('8','排水工程','./Data/project/008/'), ('9','水库','./Data/project/009/'), ('10','淤积坝','./Data/project/010/');
INSERT INTO `temp` VALUES ('1','抽水站','1'), ('2','地下水监测站','2'), ('3','机电井','3'), ('4','集中供水1000方以上','4'), ('5','集中供水1000方以下','5'), ('6','末级渠道','6'), ('7','中小河流提防','7'), ('8','排水工程','8'), ('9','水库','9'), ('10','淤积坝','10');
INSERT INTO `user` VALUES ('1','linwei','linwei','54f8350c9ced3646d68689030ad13685');
