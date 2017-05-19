/*
Navicat MySQL Data Transfer

Source Server         : 10.0.0.13_3306
Source Server Version : 100119
Source Host           : 10.0.0.13:3306
Source Database       : serverstorage

Target Server Type    : MYSQL
Target Server Version : 100119
File Encoding         : 65001

Date: 2017-05-19 02:31:10
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for clients
-- ----------------------------
DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserName` varchar(225) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserPic` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserFirstName` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserLastName` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserAccessToken` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserState` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserAccess` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserCredits` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserLevel` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserMana` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserHealth` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserExp` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserXpos` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserYpos` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserZpos` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserXrot` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserYrot` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserZrot` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserGpsX` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserGpsY` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserGpsZ` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserFirstTimeLogin` int(255) NOT NULL DEFAULT '0',
  `UserDeviceId` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserIpAddress` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `UserActivation` int(255) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

-- ----------------------------
-- Table structure for clients_gamobject_waypoints
-- ----------------------------
DROP TABLE IF EXISTS `clients_gamobject_waypoints`;
CREATE TABLE `clients_gamobject_waypoints` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `clientsid` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `relatedid` int(11) DEFAULT NULL,
  `xpos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `ypos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `zpos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `xrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `yrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `zrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

-- ----------------------------
-- Table structure for clients_message
-- ----------------------------
DROP TABLE IF EXISTS `clients_message`;
CREATE TABLE `clients_message` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `fromUserId` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `toUserId` varchar(255) COLLATE utf32_unicode_ci NOT NULL DEFAULT '0',
  `message` text COLLATE utf32_unicode_ci NOT NULL,
  `received` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

-- ----------------------------
-- Table structure for clients_objects
-- ----------------------------
DROP TABLE IF EXISTS `clients_objects`;
CREATE TABLE `clients_objects` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `pos_x` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `pos_y` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `pos_z` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `rot_x` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `rot_y` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `rot_z` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `scale_x` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `scale_y` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `scale_z` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

-- ----------------------------
-- Table structure for clients_temp
-- ----------------------------
DROP TABLE IF EXISTS `clients_temp`;
CREATE TABLE `clients_temp` (
  `Id` int(255) NOT NULL AUTO_INCREMENT,
  `UserDeviceId` varchar(255) DEFAULT '0',
  `UserCredits` varchar(255) DEFAULT '0',
  `UserGpsX` varchar(255) DEFAULT '0',
  `UserGpsY` varchar(255) DEFAULT '0',
  `UserGpsZ` varchar(255) DEFAULT '0',
  `UserIpAddress` varchar(255) DEFAULT '0',
  `UserId` varchar(255) DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for gameobjects
-- ----------------------------
DROP TABLE IF EXISTS `gameobjects`;
CREATE TABLE `gameobjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `model` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `size` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;

-- ----------------------------
-- Table structure for gamobject_waypoints
-- ----------------------------
DROP TABLE IF EXISTS `gamobject_waypoints`;
CREATE TABLE `gamobject_waypoints` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `relatedid` int(11) DEFAULT NULL,
  `xpos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `ypos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `zpos` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `xrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `yrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  `zrot` varchar(255) COLLATE utf32_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_unicode_ci;
