-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Már 24. 09:39
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `fitclock`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `admins`
--

CREATE TABLE `admins` (
  `adminId` tinyint(2) NOT NULL,
  `username` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(70) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `equipment`
--

CREATE TABLE `equipment` (
  `equipmentId` tinyint(1) NOT NULL,
  `equipmentName` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `exercise`
--

CREATE TABLE `exercise` (
  `exerciseId` tinyint(1) NOT NULL,
  `exerciseName` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `caloriesPerSec` double DEFAULT NULL,
  `exerciseIntensity` int(11) DEFAULT NULL,
  `equipmentId` tinyint(1) DEFAULT NULL,
  `muscleGroupId` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `genders`
--

CREATE TABLE `genders` (
  `genderId` tinyint(1) NOT NULL,
  `gender` varchar(30) COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `graph`
--

CREATE TABLE `graph` (
  `numberOfUsers` int(11) NOT NULL,
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `grouppic`
--

CREATE TABLE `grouppic` (
  `picId` tinyint(2) NOT NULL,
  `picture` blob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `groups`
--

CREATE TABLE `groups` (
  `groupId` tinyint(2) NOT NULL,
  `groupName` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `groupAdmin` tinyint(2) NOT NULL,
  `groupPicId` tinyint(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `grouptags`
--

CREATE TABLE `grouptags` (
  `userId` tinyint(2) NOT NULL,
  `groupId` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `muscles`
--

CREATE TABLE `muscles` (
  `musclesId` tinyint(1) NOT NULL,
  `muscleGroupName` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `quest`
--

CREATE TABLE `quest` (
  `questId` tinyint(2) NOT NULL,
  `questText` varchar(200) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `questSender` tinyint(2) NOT NULL,
  `questReciever` tinyint(2) NOT NULL,
  `questTimeToFinnish` date NOT NULL,
  `questExercise` tinyint(1) NOT NULL,
  `questExerciseTime` double NOT NULL,
  `questIsAccepted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `questresponse`
--

CREATE TABLE `questresponse` (
  `questId` tinyint(2) NOT NULL,
  `fileSize` mediumint(8) UNSIGNED NOT NULL,
  `file` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `review`
--

CREATE TABLE `review` (
  `reviewId` tinyint(2) NOT NULL,
  `userId` tinyint(2) NOT NULL,
  `graphics` tinyint(1) NOT NULL,
  `functions` tinyint(1) NOT NULL,
  `exercises` tinyint(1) NOT NULL,
  `groups` tinyint(1) NOT NULL,
  `comments` text COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `userprofilepic`
--

CREATE TABLE `userprofilepic` (
  `picId` tinyint(2) NOT NULL,
  `picture` blob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `userId` tinyint(2) NOT NULL,
  `password` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `username` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `profilePicId` tinyint(2) NOT NULL DEFAULT 1,
  `userGenderId` tinyint(1) NOT NULL,
  `birth` date DEFAULT NULL,
  `weight` smallint(3) DEFAULT NULL,
  `height` smallint(3) DEFAULT NULL,
  `email` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workout`
--

CREATE TABLE `workout` (
  `workoutId` tinyint(1) NOT NULL,
  `userId` tinyint(2) NOT NULL,
  `dateOfExercise` date DEFAULT NULL,
  `exerciseList` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`adminId`);

--
-- A tábla indexei `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`equipmentId`);

--
-- A tábla indexei `exercise`
--
ALTER TABLE `exercise`
  ADD PRIMARY KEY (`exerciseId`),
  ADD KEY `equipmentId` (`equipmentId`),
  ADD KEY `muscleGroupId` (`muscleGroupId`);

--
-- A tábla indexei `genders`
--
ALTER TABLE `genders`
  ADD PRIMARY KEY (`genderId`);

--
-- A tábla indexei `grouppic`
--
ALTER TABLE `grouppic`
  ADD PRIMARY KEY (`picId`);

--
-- A tábla indexei `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`groupId`),
  ADD KEY `groupPicId` (`groupPicId`);

--
-- A tábla indexei `grouptags`
--
ALTER TABLE `grouptags`
  ADD KEY `userId` (`userId`),
  ADD KEY `groupId` (`groupId`);

--
-- A tábla indexei `muscles`
--
ALTER TABLE `muscles`
  ADD PRIMARY KEY (`musclesId`);

--
-- A tábla indexei `quest`
--
ALTER TABLE `quest`
  ADD PRIMARY KEY (`questId`),
  ADD KEY `questSender` (`questSender`),
  ADD KEY `questReciever` (`questReciever`),
  ADD KEY `questExercise` (`questExercise`);

--
-- A tábla indexei `questresponse`
--
ALTER TABLE `questresponse`
  ADD KEY `questId` (`questId`);

--
-- A tábla indexei `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`reviewId`),
  ADD KEY `userId` (`userId`);

--
-- A tábla indexei `userprofilepic`
--
ALTER TABLE `userprofilepic`
  ADD PRIMARY KEY (`picId`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userId`),
  ADD KEY `profilePicId` (`profilePicId`),
  ADD KEY `userGenderId` (`userGenderId`);

--
-- A tábla indexei `workout`
--
ALTER TABLE `workout`
  ADD PRIMARY KEY (`workoutId`),
  ADD KEY `userId` (`userId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `admins`
--
ALTER TABLE `admins`
  MODIFY `adminId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `equipment`
--
ALTER TABLE `equipment`
  MODIFY `equipmentId` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `exercise`
--
ALTER TABLE `exercise`
  MODIFY `exerciseId` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `genders`
--
ALTER TABLE `genders`
  MODIFY `genderId` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `grouppic`
--
ALTER TABLE `grouppic`
  MODIFY `picId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `groups`
--
ALTER TABLE `groups`
  MODIFY `groupId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `muscles`
--
ALTER TABLE `muscles`
  MODIFY `musclesId` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `quest`
--
ALTER TABLE `quest`
  MODIFY `questId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `review`
--
ALTER TABLE `review`
  MODIFY `reviewId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `userprofilepic`
--
ALTER TABLE `userprofilepic`
  MODIFY `picId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `userId` tinyint(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `workout`
--
ALTER TABLE `workout`
  MODIFY `workoutId` tinyint(1) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `exercise`
--
ALTER TABLE `exercise`
  ADD CONSTRAINT `exercise_ibfk_1` FOREIGN KEY (`equipmentId`) REFERENCES `equipment` (`equipmentId`),
  ADD CONSTRAINT `exercise_ibfk_2` FOREIGN KEY (`muscleGroupId`) REFERENCES `muscles` (`musclesId`);

--
-- Megkötések a táblához `groups`
--
ALTER TABLE `groups`
  ADD CONSTRAINT `groups_ibfk_1` FOREIGN KEY (`groupPicId`) REFERENCES `grouppic` (`picId`);

--
-- Megkötések a táblához `grouptags`
--
ALTER TABLE `grouptags`
  ADD CONSTRAINT `grouptags_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`userId`),
  ADD CONSTRAINT `grouptags_ibfk_2` FOREIGN KEY (`groupId`) REFERENCES `groups` (`groupId`);

--
-- Megkötések a táblához `quest`
--
ALTER TABLE `quest`
  ADD CONSTRAINT `quest_ibfk_1` FOREIGN KEY (`questSender`) REFERENCES `users` (`userId`),
  ADD CONSTRAINT `quest_ibfk_2` FOREIGN KEY (`questReciever`) REFERENCES `users` (`userId`),
  ADD CONSTRAINT `quest_ibfk_3` FOREIGN KEY (`questExercise`) REFERENCES `exercise` (`exerciseId`);

--
-- Megkötések a táblához `questresponse`
--
ALTER TABLE `questresponse`
  ADD CONSTRAINT `questresponse_ibfk_1` FOREIGN KEY (`questId`) REFERENCES `quest` (`questId`);

--
-- Megkötések a táblához `review`
--
ALTER TABLE `review`
  ADD CONSTRAINT `review_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`userId`);

--
-- Megkötések a táblához `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`profilePicId`) REFERENCES `userprofilepic` (`picId`),
  ADD CONSTRAINT `users_ibfk_2` FOREIGN KEY (`userGenderId`) REFERENCES `genders` (`genderId`);

--
-- Megkötések a táblához `workout`
--
ALTER TABLE `workout`
  ADD CONSTRAINT `workout_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`userId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
