/*
 Navicat MySQL Data Transfer

 Source Server         : dev
 Source Server Type    : MySQL
 Source Server Version : 80100
 Source Host           : localhost:3306
 Source Schema         : hyf

 Target Server Type    : MySQL
 Target Server Version : 80100
 File Encoding         : 65001

 Date: 08/07/2024 22:58:54
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`  (
  `id` int NOT NULL DEFAULT 1001,
  `account` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `pwd` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES (1001, '小明', '1234');
INSERT INTO `account` VALUES (1003, ' 小红', '789');

-- ----------------------------
-- Table structure for bag
-- ----------------------------
DROP TABLE IF EXISTS `bag`;
CREATE TABLE `bag`  (
  `cfgId` int NULL DEFAULT NULL,
  `uid` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sum` int NULL DEFAULT NULL,
  `roleId` int NULL DEFAULT NULL,
  PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of bag
-- ----------------------------
INSERT INTO `bag` VALUES (2, '1001', 1, 1001);
INSERT INTO `bag` VALUES (1, '1002', 1, 1001);
INSERT INTO `bag` VALUES (2412, '11', 11, 1001);
INSERT INTO `bag` VALUES (3, '121', 21, 1001);
INSERT INTO `bag` VALUES (2413, '14', 14, 1001);
INSERT INTO `bag` VALUES (40001, '212', 212, 1001);
INSERT INTO `bag` VALUES (10001, '2321', 1000, 1002);
INSERT INTO `bag` VALUES (30010, '45356', 54, 1001);
INSERT INTO `bag` VALUES (6, '54', 100, 1002);
INSERT INTO `bag` VALUES (31007, '645', 141, 1001);
INSERT INTO `bag` VALUES (30001, '80', 212, 1002);
INSERT INTO `bag` VALUES (2401, '81', 22, 1001);

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int NOT NULL DEFAULT 1001,
  `nickname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `pwd` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `uid` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `age` int NULL DEFAULT NULL,
  `lv` int NULL DEFAULT NULL,
  `gender` int NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES (1001, 'z1001', '1234', '212', 21, 1, 1);
INSERT INTO `role` VALUES (1002, 'z1002', '1002', '21221', 212, 212, 1);

SET FOREIGN_KEY_CHECKS = 1;
