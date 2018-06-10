

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `martinwahlberg_no_kolonial`
--
CREATE DATABASE `martinwahlberg_no_kolonial` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `martinwahlberg_no_kolonial`;

-- --------------------------------------------------------

--
-- Table structure for table `auth`
--

CREATE TABLE IF NOT EXISTS `auth` (
  `token` varchar(500) NOT NULL,
  `emailUser` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `awakeCheck`
--


-- --------------------------------------------------------

--
-- Table structure for table `kuponger`
--

CREATE TABLE IF NOT EXISTS `kuponger` (
  `mailC` varchar(300) NOT NULL,
  `kupongid` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- --------------------------------------------------------

--
-- Table structure for table `lodd`
--

CREATE TABLE IF NOT EXISTS `lodd` (
  `userM` varchar(300) NOT NULL,
  `lotteryInfo` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `points`
--

CREATE TABLE IF NOT EXISTS `points` (
  `pointMail` varchar(250) NOT NULL,
  `totalPoints` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tilbud`
--

CREATE TABLE IF NOT EXISTS `tilbud` (
  `tilbud` varchar(300) NOT NULL,
  `id` varchar(300) NOT NULL,
  `fordel` varchar(300) NOT NULL,
  `imgurl` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tilbud`
--

INSERT INTO `tilbud` (`tilbud`, `id`, `fordel`, `imgurl`) VALUES
('WANTED Iskrem', 'iskremidtilbid', '2 for 3', 'https://kolonial.no/media/uploads/public/334/294/699894-4b571-product_detail.jpg'),
('Tine Meieri-smør', 'meierismorjfj', '20% på neste kjøp', 'https://kolonial.no/media/uploads/public/44/87/680487-e0928-product_detail.jpg'),
('Maruud Popcorn', 'popiscornalis', 'Gratis ved neste kjøp', 'https://kolonial.no/media/uploads/public/198/51/685251-35736-product_detail.jpg'),
('Sprøstekt løk', 'pyldre', 'Gratis ved kjøp av pølse', 'https://kolonial.no/media/uploads/public/357/175/679375-9c329-product_detail.jpg'),
('Wienerpølse', 'fjlkfdjs', '2 for 3', 'https://kolonial.no/media/uploads/public/111/181/646181-46657-product_detail.jpg'),
('Fanta Orange', 'fantnaj', '2 for 1', 'https://kolonial.no/media/uploads/public/184/14/682414-cbfa9-product_detail.jpg'),
('Tran', 'tranost', 'Gratis ved kjøp av Ost', 'https://kolonial.no/media/uploads/public/174/194/702594-43a18-product_detail.jpg'),
('Grillribbe', 'grillsak', 'Halv pris ved neste kjøp', 'https://kolonial.no/media/uploads/public/0/387/18787-fda2b-product_detail.jpg'),
('Melon', 'melonasda', '2 for 1', 'https://kolonial.no/media/uploads/public/259/137/722937-b1131-product_detail.jpg'),
('Toalettpapir', 'toafor2', '5 for 3', 'https://kolonial.no/media/uploads/public/342/136/722936-79868-product_detail.jpg'),
('Skinke', 'gratismedbrod', 'Få gratis ved kjøp av brød', 'https://kolonial.no/media/uploads/public/60/13/154813-9d364-product_detail.jpg'),
('Ingen flere tilbud', 'ugyldig', '', 'https://kolonial.no/static/products/img/placeholder.bffcea8d3530.png'),
('Ingen flere tilbud', 'ugyldig', '', 'https://kolonial.no/static/products/img/placeholder.bffcea8d3530.png'),
('Ingen flere tilbud', 'ugyldig', '', 'https://kolonial.no/static/products/img/placeholder.bffcea8d3530.png');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `userEmail` varchar(250) NOT NULL,
  `userFName` varchar(250) NOT NULL,
  `userLName` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
