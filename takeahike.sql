-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 22, 2019 at 09:22 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `takeahike`
--
CREATE DATABASE IF NOT EXISTS `takeahike` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `takeahike`;

-- --------------------------------------------------------

--
-- Table structure for table `hikers`
--

CREATE TABLE `hikers` (
  `id` int(11) NOT NULL,
  `hiker_name` varchar(255) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `zip` int(11) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `gender` int(11) NOT NULL,
  `car` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `hikers_trails`
--

CREATE TABLE `hikers_trails` (
  `id` int(11) NOT NULL,
  `hiker_id` int(11) NOT NULL,
  `trail_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `trails`
--

CREATE TABLE `trails` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `difficulty` int(11) NOT NULL,
  `distance` float NOT NULL,
  `summits` int(11) NOT NULL,
  `waterfalls` tinyint(1) NOT NULL,
  `streams` tinyint(1) NOT NULL,
  `mountain_views` tinyint(1) NOT NULL,
  `meadows` tinyint(1) NOT NULL,
  `lakes` tinyint(1) NOT NULL,
  `dogs` tinyint(1) NOT NULL,
  `location` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `trails`
--

INSERT INTO `trails` (`id`, `name`, `difficulty`, `distance`, `summits`, `waterfalls`, `streams`, `mountain_views`, `meadows`, `lakes`, `dogs`, `location`) VALUES
(1, 'Trail Name', 3, 5, 1, 1, 1, 1, 1, 1, 1, 'Olympic Peninsula'),
(2, 'Black Diamond Open Space', 3, 17, 2, 0, 1, 1, 0, 0, 1, 'Snoqualmie'),
(3, 'Teneriffe Falls', 2, 5.6, 1, 1, 1, 1, 0, 0, 1, 'Snoqualmie Region '),
(4, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(5, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(6, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(7, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(8, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(9, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 0, 0, 1, ''),
(10, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(11, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(12, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(13, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(14, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(15, 'Anti-Aircraft Peak ', 2, 4.75, 2, 0, 0, 1, 1, 1, 1, ''),
(16, 'Trail Name', 1, 5, 1, 1, 1, 0, 0, 0, 1, ''),
(17, 'Trail Name', 1, 5, 1, 1, 1, 0, 0, 0, 1, ''),
(18, 'Cougar Mountain ', 4, 17, 3, 0, 0, 1, 0, 0, 0, ''),
(19, 'Cougar Mountain ', 4, 17, 3, 0, 0, 1, 0, 0, 0, ''),
(20, 'Cougar Mountain ', 4, 17, 3, 0, 0, 1, 0, 0, 0, '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hikers`
--
ALTER TABLE `hikers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hikers_trails`
--
ALTER TABLE `hikers_trails`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trails`
--
ALTER TABLE `trails`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hikers`
--
ALTER TABLE `hikers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `hikers_trails`
--
ALTER TABLE `hikers_trails`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `trails`
--
ALTER TABLE `trails`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
