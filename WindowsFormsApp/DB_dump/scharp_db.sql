-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Erstellungszeit: 05. Jan 2022 um 22:08
-- Server-Version: 5.6.47
-- PHP-Version: 7.3.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `scharp_db`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `literature`
--

CREATE TABLE `literature` (
  `id` int(11) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL,
  `first_word_name` varchar(50) NOT NULL,
  `year` int(5) NOT NULL,
  `path` text NOT NULL,
  `surname_autor` varchar(100) NOT NULL,
  `autor` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `literature`
--

INSERT INTO `literature` (`id`, `name`, `first_word_name`, `year`, `path`, `surname_autor`, `autor`) VALUES
(5, 'A Survey on Mismatching and Aging of PV Modules: The Closed Loop', 'Survey', 2015, '1___manganiello___2015_ускорение_деградации.pdf', 'Manganiello', 'Patrizio Manganiello, Marco Balato, and Massimo Vitelli'),
(4, 'Solar Energy', 'Solar', 2016, '0_base___Santolo_2016_.pdf', 'Daliento', 'Santolo Daliento, Fabio Di Napoli, Pierluigi Guerriero'),
(6, 'Solar Energy', 'Solar', 2015, '3__Basri__.2015.02.048.pdf', 'Basri', 'Y. El Basri, M. Bressan, L. Seguier'),
(7, 'HOT SPOT INVESTIGATIONS ON PV MODULES', 'HOT', 1997, '4__Herrmann_.1997.654287.pdf', 'Herrmann', 'W. Herrmann, W. Wiesner, W. Vaanen'),
(8, 'Reexamination of Photovoltaic Hot Spotting to Show\r\nInadequacy of the Bypass Diode', 'Reexamination', 2015, '7___kim___2015.pdf', 'Kim', 'Katherine A. Kim, Philip T. Krein'),
(9, 'Solid-State Electronics', 'Solid', 2011, '8a__dalessandro__2011.pdf', 'd\'Alessandro', 'Vincenzo d\'Alessandro, Pierluigi Guerriero, Santolo Daliento, Matteo Gargiulo'),
(10, 'Accurately extracting the shunt resistance of photovoltaic cells in installed module strings', 'Accurately', 2011, '8c__dalessandro__2011.pdf', 'D\'Alessandro', 'Vincenzo D\'Alessandro, Santolo Daliento, Pierluigi Guerriero'),
(11, 'Solar EnergyMaterials&SolarCells', 'Solar', 2010, '9__simon2010.pdf', 'Simon', 'Michael Simon, EdsonL.Meyer'),
(12, 'SHADOW TOLERANCE OF MODULES INCORPORATING INTEGRAL BYPASS DIODE SOLAR CELLS', 'SHADOW', 1986, '10__Suryanto_Hasym ___1986.pdf', 'HASYIM', 'E. SURYANTO HASYIM, S. R. WENHAM and M. A. GREEN'),
(13, 'Study of crystalline silicon solar cells with integrated bypass diodes', 'Study', 2012, '11_Chen_2012.pdf', 'KaiHan', 'CHEN KaiHan, CHEN DaMing, ZHU YanBin & SHEN Hui'),
(14, 'Analytical modelling and minority current measurements for the determination of the emitter surface recombination velocity in silicon solar cells', 'Analytical', 2007, '12a___daliento__2007.pdf', 'Dalientoa', 'Santolo Dalientoa,, Luigi Melea, Eugenia Bobeicob, Laura Lancellottib, Pasquale Morvillo'),
(15, 'On the design and the control of a coupledinductors\r\nboost dc-ac converter for an\r\nindividual PV panel', 'design', 2012, '13___Coppola__2012.pdf', 'Coppola', 'Marino Coppola, Santolo Daliento'),
(16, 'Hot-spot mitigation in PV arrays with distributed MPPT (DMPPT)', 'Hot-spot', 2013, '14___solrzano__2014.pdf', 'Solo\'rzano', 'J. Solo\'rzano, M.A. Egido'),
(17, 'Accurate Maximum Power Tracking in Photovoltaic Systems Affected by Partial Shading', 'Accurate', 2015, '15b__guerriero___2016.pdf', 'Guerriero', 'Pierluigi Guerriero, Fabio Di Napoli, Vincenzo d’Alessandro, and Santolo Daliento'),
(18, 'Real time monitoring of solar fields with cost/revenue analysis of fault fixing', 'Real', 2016, '15c__guerriero___2016.pdf', 'Guerriero', 'Pierluigi Guerriero, Fabio Di Napoli, Santolo Daliento'),
(19, 'Single-Panel Voltage Zeroing System for Safe Access on PV Plants', 'Single-Panel', 2015, '16__Napoli___.2015.2448416.pdf', 'Napoli', 'F. Di Napoli, P. Guerriero, V. d’Alessandro, and S. Daliento'),
(20, 'Fatigue degradation and electric\r\nrecovery in Silicon solar cells embedded\r\nin photovoltaic modules', 'Fatigue', 2014, '17___paggi___2014.pdf', 'Paggi', 'Marco Paggi, Irene Berardone, Andrea Infuso & Mauro Corrado'),
(21, 'Characteristics of Different Solar PV Modules under Partial Shading', 'Characteristics ', 2014, '18_Hla_Hla_Khaing__2014.pdf', 'Khaing', 'Hla Hla Khaing, Yit Jian Liang, Nant Nyein Moe Htay, Jiang Fan');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(100) NOT NULL,
  `pass` varchar(32) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `name`) VALUES
(12, 'testW', '12345q', 'Wolf');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `literature`
--
ALTER TABLE `literature`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indizes für die Tabelle `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `literature`
--
ALTER TABLE `literature`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
