-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 08 mars 2024 à 14:54
-- Version du serveur : 10.4.25-MariaDB
-- Version de PHP : 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bddpersonnels`
--

-- --------------------------------------------------------

--
-- Structure de la table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `nom` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `admin`
--

INSERT INTO `admin` (`id`, `nom`, `password`) VALUES
(1, 'admin', 'Password1234!');

-- --------------------------------------------------------

--
-- Structure de la table `fonctions`
--

CREATE TABLE `fonctions` (
  `id` int(11) NOT NULL,
  `intitule` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `fonctions`
--

INSERT INTO `fonctions` (`id`, `intitule`) VALUES
(1, 'Professeur'),
(2, 'Agent technique'),
(3, 'Surveillant'),
(11, 'CPE'),
(12, 'CPE');

-- --------------------------------------------------------

--
-- Structure de la table `personnels`
--

CREATE TABLE `personnels` (
  `id` int(11) NOT NULL,
  `prenom` text CHARACTER SET latin1 NOT NULL,
  `nom` text CHARACTER SET latin1 NOT NULL,
  `idService` int(11) NOT NULL,
  `idFonction` int(11) NOT NULL,
  `telephone` text CHARACTER SET latin1 DEFAULT NULL,
  `photo` blob DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Déchargement des données de la table `personnels`
--

INSERT INTO `personnels` (`id`, `prenom`, `nom`, `idService`, `idFonction`, `telephone`, `photo`) VALUES
(1, 'John', 'Doe', 1, 1, '555-1234', 0x6a6f686e2e6a7067),
(2, 'Alice', 'Smith', 2, 2, '555-5678', 0x616c6963652e6a7067),
(3, 'Bob', 'Johnson', 3, 3, '555-9012', 0x626f622e6a7067),
(4, 'Emma', 'Williams', 1, 1, '555-3456', 0x656d6d612e6a7067),
(5, 'Michael', 'Brown', 2, 2, '555-7890', 0x6d69636861656c2e6a7067),
(6, 'Sophia', 'Jones', 3, 3, '555-2345', 0x736f706869612e6a7067),
(7, 'William', 'Garcia', 1, 1, '555-6789', 0x77696c6c69616d2e6a7067),
(8, 'Olivia', 'Martinez', 2, 2, '555-0123', 0x6f6c697669612e6a7067),
(9, 'James', 'Lopez', 3, 3, '555-4567', 0x6a616d65732e6a7067),
(10, 'Amelia', 'Lee', 1, 1, '555-8901', 0x616d656c69612e6a7067);

-- --------------------------------------------------------

--
-- Structure de la table `services`
--

CREATE TABLE `services` (
  `id` int(11) NOT NULL,
  `intitule` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `services`
--

INSERT INTO `services` (`id`, `intitule`) VALUES
(1, 'Mathématiques'),
(2, 'Physique'),
(3, 'Informatique');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `fonctions`
--
ALTER TABLE `fonctions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_UNIQUE` (`id`);

--
-- Index pour la table `personnels`
--
ALTER TABLE `personnels`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_UNIQUE` (`id`),
  ADD KEY `idService` (`idService`),
  ADD KEY `idFonction` (`idFonction`);

--
-- Index pour la table `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_UNIQUE` (`id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `fonctions`
--
ALTER TABLE `fonctions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `personnels`
--
ALTER TABLE `personnels`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT pour la table `services`
--
ALTER TABLE `services`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `personnels`
--
ALTER TABLE `personnels`
  ADD CONSTRAINT `affect_ibfk_1` FOREIGN KEY (`idService`) REFERENCES `services` (`id`),
  ADD CONSTRAINT `affect_ibfk_2` FOREIGN KEY (`idFonction`) REFERENCES `fonctions` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
