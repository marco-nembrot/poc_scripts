-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 26 Septembre 2014 à 07:49
-- Version du serveur :  5.6.20
-- Version de PHP :  5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `poc`
--

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

CREATE TABLE IF NOT EXISTS `categorie` (
  `nom` varchar(255) NOT NULL,
  `parent` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `categorie`
--

INSERT INTO `categorie` (`nom`, `parent`) VALUES
('Tutoriel', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `niveau`
--

CREATE TABLE IF NOT EXISTS `niveau` (
  `nom` varchar(30) NOT NULL,
  `categorie` varchar(255) NOT NULL,
  `ordre` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `niveau`
--

INSERT INTO `niveau` (`nom`, `categorie`, `ordre`) VALUES
('COEUR', 'Tutoriel', 3),
('JESUS', 'Tutoriel', 1),
('MARIE', 'Tutoriel', 2),
('SAINT ESPRIT', 'Tutoriel', 4);

-- --------------------------------------------------------

--
-- Structure de la table `paragraphe`
--

CREATE TABLE IF NOT EXISTS `paragraphe` (
`id` int(11) NOT NULL,
  `niveau` varchar(30) NOT NULL,
  `texte` text CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `position` int(11) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=33 ;

--
-- Contenu de la table `paragraphe`
--

INSERT INTO `paragraphe` (`id`, `niveau`, `texte`, `position`) VALUES
(1, 'JESUS', 'Il peut para&#238;tre difficile de reconna&#238;tre Dieu sous le visage humain de J&#233;sus venu parmi les hommes il y a 2000 ans. J&#233;sus signifie &quot;Dieu sauve&quot;. Son nom est d&#233;j&#224; un programme, une mission &#224; r&#233;aliser. Il est n&#233; &#224; Bethl&#233;em en Jud&#233;e au sud de la Palestine. Ses parents, Joseph et Marie, habitaient Nazareth en Galil&#233;e.', 0),
(2, 'JESUS', 'J&#233;sus a pratiqu&#233; le m&#233;tier de menuisier charpentier jusqu&#39;&#224; l&#39;&#226;ge de trente ans. Certains historiens des premiers si&#232;cles attestent de l&#39;existence de J&#233;sus sans pour autant croire qu&#39;il est le Fils de Dieu. Mais ce sont les Evangiles qui constituent une source essentielle pour notre connaissance de J?sus. Ecrits par des auteurs diff&#233;rents, ils nous font entrer &#224; partir des r&#233;cits de sa vie dans l&#39;intimit&#233; profonde de sa relation &#224; Dieu.', 1),
(3, 'JESUS', 'Apr&#232;s trente ans de &quot;vie ordinaire&quot; &#224; Nazareth, J&#233;sus quitte la maison, s&#39;&#233;tablit &#224; Capharna&#252;m, au bord du lac de Tib&#233;riade et appelle douze compagnons, les ap&#244;tres, c&#39;est-&#224;-dire &quot;ceux qui sont envoy&#233;s&quot;. Ce chiffre 12, &#233;voquant les douze tribus d&#39;Isra&#235;l, symbolise le peuple de Dieu que J&#233;sus vient rassembler. Avec eux, J&#233;sus parcourt le pays pour annoncer l&#39;amour de Dieu et appeler &#224; la conversion.', 2),
(4, 'JESUS', 'Ils seront les t&#233;moins privil&#233;gi&#233;s de tout ce qui va se passer au cours de ses trois ann&#233;es de vie publique. J&#233;sus conteste souvent l&#39;image que le gens se font de Dieu. En m&#234;me temps, il lib&#232;re de leurs craintes tous ceux qui se croient &#233;cart&#233;s de Lui. J&#233;sus, comme Dieu lui-m&#234;me, voit le fond des coeurs.\r\nQuand les Chr&#233;tiens disent que J&#233;sus est le Fils de Dieu, ils expriment qu&#39;entre lui et Dieu il n&#39;est que communion et confiance totale : &quot;Moi je connais Dieu, parce que je viens d&#39;aupr&#232;s de Lui et c&#39;est Lui qui m&#39;a envoy&#233;.&quot; &quot;Croyez-moi, je suis dans le P&#232;re, et le P&#232;re est en moi&quot; ; (Jean 7, 29 ; 14,11).', 3),
(5, 'JESUS', 'J&#233;sus ne se situe pas seulement comme proph&#232;te transmettant la Parole de Dieu. Il est lui-m&#234;me cette parole vivante, le &quot;Verbe de Dieu&quot; qui &quot;d&#233;voile&quot; le vrai visage de Dieu p&#232;re et sa pr&#233;sence ind&#233;fectible au milieu des hommes. Il est vraiment le Fils, l&#39;une des trois personnes divines de la Trinit&#233;.', 4),
(6, 'MARIE', '? Comme vraie ?fille de Sion?, Marie est figure de l?Eglise, figure de l?homme croyant qui ne peut arriver au salut et ? la r?alisation pl?ni?re de lui-m?me que par le don de l?amour ? par gr?ce ?.\r\n\r\nJoseph Ratzinger, Foi chr?tienne', 0),
(7, 'MARIE', '? C?est un fait assez paradoxal. Le culte de la Vierge est un sujet de division, non seulement entre les confessions chr?tiennes, mais entre les catholiques eux-m?mes. Les uns pensent qu?? l??gard de Marie, on n?en fait et on n?en dit jamais trop. Les autres ont plut?t tendance ? garder une certaine r?serve, voire ? justifier aux nom de la foi la distance qu?ils prennent ? l??gard de certaines d?votions mariales qu?ils soup?onnent de nourrir une pi?t? plus sentimentale que r?fl?chie ?.', 1),
(8, 'MARIE', '? C?est en prenant ses appuis sur l?Ecriture et sur la plus ancienne Tradition de l?Eglise, celle de l?Orient comme celle de l?Occident chr?tien, que le Cat?chisme de l?Eglise Catholique formule les enseignements qui fondent le culte marial. Apr?s avoir ?voqu? les diff?rentes formes qu?il rev?t dans l?Eglise, il les fonde sur le r?le que tient la Vierge dans l??conomie globale du salut telle que la R?v?lation l?a fait conna?tre. Au-del? des interpr?tations divergentes, il est incontestable que Marie occupe une place privil?gi?e dans l?accomplissement r?dempteur et la communion des saints ?.', 2),
(9, 'MARIE', 'L?attention ? l?Ecriture conduit d?elle-m?me ? l?autre lieu concret o? l?Eglise apprend ? conna?tre qui elle doit conna?tre dans la foi. Ce que l?unit? du Nouveau et de l?Ancien Testament invite ? reconna?tre de la place de Marie, m?re de J?sus, dans l??uvre du salut, renvoie ? la vie du peuple de Dieu en son int?gralit?. La pr?sentation de Marie que donnent les ?crits n?o-testamentaires se nourrit de la lecture de l?Ancien Testament ; elle se r?f?re tout autant ? ce que la gr?ce du Christ donne aux croyants de tous temps et de tous lieux de recevoir et de d?ployer. Puisque Marie est la croyante en qui ?cl?t pleinement la foi d?Abraham et des p?res, l?Eglise se doit de reconna?tre en elle la pl?nitude de l?exp?rience et de la foi et de la gr?ce qu?elle fait ? travers les si?cles. ', 3),
(10, 'MARIE', 'Certains chr?tiens, m?me catholiques, sont d?rout?s d?entendre l?Eglise affirmer de Marie bien des qualit?s que l?Ecriture sainte ne mentionne pas directement. Les mentions de la M?re de J?sus sont peu nombreuses, trop peu, para?t-il, pour soutenir l?imposant ?difice des dogmes mariaux. En r?alit?, l?importance des quelques passages d?crivant l?action ou signalant la pr?sence de Marie ou de la m?re de J?sus, ne tient pas ? la somme des informations qu?ils fournissent, mais ? leur place strat?gique et ? l?arri?re-fond qu?ils mobilisent d?une lecture de la Bible m?dit?e au long des si?cles d?Isra?l. ', 4),
(11, 'COEUR', '? L?essentiel est invisible pour les yeux ?, dit le renard. Le petit prince r?p?te la phrase pour s?en souvenir, un moyen, pour l?auteur, de nous indiquer son importance pour la compr?hension de l?histoire. Il l?avait d?j? fait en commen?ant son texte avec les dessins de serpent boa ? ouvert ? et ? ferm? ?, susceptibles de nous indiquer que chaque chose, chaque ?tre cache un tr?sor, un myst?re que nous devons percer. Au-del? des apparences, il y a l?esprit qu?il faut d?couvrir avec le c?ur.', 0),
(12, 'COEUR', 'L?esprit rend les choses uniques. Il est l?aboutissement de nos choix, de nos efforts, de l?amiti?, de l?amour. Mille roses dans un jardin ressemblent ? celle que le petit prince a laiss?e sur sa plan?te, mais celle-ci est unique parce qu?il l?a arros?e, parce qu?il l?a prot?g?e, parce qu?il l?a ? apprivois?e ?, pour reprendre les mots du renard qui ajoute : ? Tu deviens responsable pour toujours de ce que  tu as apprivois?. ? L?esprit cr?e des liens. Gr?ce ? lui, le monde se peuple de signes : tel champ de bl? rappelle les cheveux dor?s du Petit Prince, les ?toiles sont des grelots qui rappellent son rire, le ciel est habit? de plan?tes o? grincent de vieux puits parce que sur l?une d?entre elle vit un ami aviateur qui en avait trouv? un dans le d?sert. La vie v?ritable est dans l?esprit qui, au besoin, se passe bien de la mati?re, de ? l??corce ? : pour retrouver sa rose, Le Petit Prince sacrifie son corps de chair, il se fait mordre par le serpent venimeux : ? J?aurai l?air d??tre mort et ce ne sera pas vrai? ?, nous dit-il comme dernier message.', 1),
(13, 'COEUR', 'Dans le Petit Prince, nous retenons tous la le?on du renard : ? si tu veux un ami, apprivoise-moi ? (chapitre XXI). C?est ? travers cet enseignement que le Petit Prince arrive ? comprendre ce qu?il ressent pour sa rose : ? Je crois qu?elle m?a apprivois? ? (chapitre XXI). Le Petit Prince comprend qu?en apprivoisant, il arrive ? faire sortir de la ? masse ? un ?tre qui devient, pour lui, ? unique au monde ?. Par ces mots Saint-Exup?ry veut nous faire comprendre que nos yeux seuls ne peuvent pas percevoir la singularit? d?un individu, d?une chose. Ces derniers sont enferm?s dans leur apparence et c?est seulement en les apprivoisant que nous pourrons les conna?tre et appr?cier leur singularit?.', 2),
(14, 'COEUR', '? Bien s?r, ma rose ? moi, un passant ordinaire croirait qu?elle vous ressemble. Mais ? elle seule elle est plus importante que vous toutes, puisque c?est elle que j?ai arros?e. Puisque c?est elle que j?ai mise sous globe. Puisque c?est elle que j?ai abrit?e par le paravent. Puisque c?est elle dont j?ai tu? les chenilles. Puisque c?est elle que j?ai ?cout?e se plaindre, ou se vanter, ou m?me quelquefois se taire? ? (Chapitre XXI). C?est gr?ce ? la somme de ces efforts que le Petit Prince a rendu sa rose unique au monde et qu?il en est tomb? amoureux.', 3),
(15, 'COEUR', 'Il faudra au Petit Prince un voyage d?un an pour comprendre ses sentiments envers sa rose. Comprendre que le plaisir d?une rencontre se termine par la douleur d?une s?paration. Apprivoiser un ?tre, c?est accepter de le voir dispara?tre un jour ou l?autre. La ? disparition prochaine ? de sa rose, c?est ce qui plonge le Petit Prince dans la m?lancolie et qui le pousse ? se laisser mordre par le serpent pour la rejoindre sur B612.', 4),
(16, 'SAINT ESPRIT', 'Oui, les chr&eacute;tiens croient en l''Esprit de Dieu, que l''on appelle "Esprit Saint", cette présence de Dieu en nous. La Bible utilise plusieurs images pour parler de l''Esprit Saint : le souffle qui fait respirer ; le vent qui pousse au large ; l''huile qui donne force aux athlètes ; le feu qui réchauffe et purifie ; la colombe qui descend du ciel.', 0),
(17, 'SAINT ESPRIT', 'Dieu le partage en plénitude, de toute éternité, avec son Fils Jésus. C''est parce qu''il est rempli de l?Esprit Saint que Jésus peut parler et agir au nom de Dieu. Mais Jésus n''a jamais voulu garder pour lui ce don merveilleux : il a promis à ses disciples de le répandre sur eux. Nous, chrétiens, recevons l''Esprit Saint au Baptême et à la Confirmation ; il nous fait entrer dans une relation forte et intime avec Dieu ; il nous accompagne tout au long de notre vie.', 1),
(24, 'SAINT ESPRIT', 'L?Esprit de Dieu lib?re notre capacit? d?aimer comme Dieu aime. Il nous pousse ? faire des choix qui augmentent l?amour, la paix, la tol?rance, les bienfaits, tout ce qui rend le monde plus humain et plus fraternel. L?Esprit Saint nous change int?rieurement, il met en nous un ? air de famille ? avec Dieu, comme des enfants d?un m?me P?re. Saint Paul ?crit que l?Esprit nous pousse ? dire ? Papa ? ? Dieu. Nous n?avons plus peur de Dieu, nous comprenons qu?il est ? Notre P?re ? comme J?sus l?a dit.', 2),
(25, 'SAINT ESPRIT', 'J?sus a promis d?envoyer l?Esprit Saint aux croyants. Cette promesse s?est r?alis?e le jour de la Pentec?te quand ses ap?tres on re?u l?Esprit ; qui leur a donn? le courage d?annoncer la r?surrection de J?sus ? J?rusalem, puis dans tout l?empire romain. L?Esprit fait ainsi grandir l?Eglise dans le monde entier, et l?Eglise ? son tour offre ? tous cet Esprit Saint par les sacrements du Bapt?me et de la Confirmation.', 3),
(26, 'SAINT ESPRIT', 'C?est l?Esprit qui nous permet de croire, de renouveler notre confiance en Dieu le P?re, d??couter J?sus et de trouver notre place dans l?Eglise. La pri?re nous met ? son ?coute, dans le silence, ? l?exemple de J?sus qui priait beaucoup. Un simple signe de croix ? au nom du P?re, du Fils et du saint Esprit ?, ? l?entr?e d?une ?glise, est d?j? ouverture ? son action. Et dans la Bible, l?Esprit a donn? des paroles de v?rit?, toujours d?actualit? sur nous !', 4),
(27, 'SAINT ESPRIT', '? L?Esprit souffle o? il veut ?, a expliqu? un jour J?sus : une parole, une lecture, une rencontre, tout lui est bon pour se diffuser, m?me aux non-chr?tiens. L?Esprit de Dieu n?est pas la propri?t? des chr?tiens ou de l?Eglise , c?est l?Eglise qui est sous l?inspiration de l?Esprit Saint qui est Dieu.', 5),
(28, 'SAINT ESPRIT', 'Les premier th?ologiens chr?tiens aimaient utiliser l?image du soleil : l?astre qui est difficile ? regarder tellement il irradie, qui est la source de la lumi?re et de la chaleur, c?est l?image du P?re ; la lumi?re qui vient de Lui et qui nous ?claire, c?est l?image du Fils ; la chaleur qu?on ne voit pas, qui se diffuse et qui r?chauffe, c?est l?image de l?Esprit. L?astre, la lumi?re, la chaleur, tout est l?unique soleil? le P?re, le Fils et l?Esprit sont un seul Dieu, Dieu unique qui se diffuse vers nous? les chr?tiens ont invent? un mot pour dire cette unit? de Dieu en trois personnes : la ? Trinit? ?.', 6),
(29, 'SAINT ESPRIT', 'L?Esprit Saint est mon d?fenseur, avec lui je n?ai pas peur des ? esprits mauvais ? ! Quand nous nous accusons avec un esprit n?gatif, l?Esprit nous d?fend comme un avocat car "Dieu est plus grand que notre c?ur" ?crit saint Jean. Quand nous touchons le fond, quand nous broyons du noir, l?Esprit nous d?fend comme un combattant pour nous remettre debout. Car Dieu veut le bonheur de ses enfants. ? La gloire de Dieu, c?est l?homme vivant et la vie de l?homme, c?est la vision de Dieu ? : cette phrase d?un P?re de l?Eglise m?aide souvent dans ma foi? Je crois que c?est l?Esprit Saint qui me la rappelle?', 7),
(30, 'SAINT ESPRIT', 'Quant ? l?association faite entre l?Esprit Saint et la colombe, on la trouve dans l?Evangile de Marc (1,10), quand celui-ci nous rapporte que, au jour de son bapt?me dans les eaux du Jourdain, ? J?sus vit le ciel se d?chirer et l?Esprit descendre comme une colombe.\r\nMais, en fait, le symbolisme de la colombe a des racines plus anciennes. Bien avant que la Bible soit ?crite, d?s le troisi?me mill?naire avant J?sus-Christ, au Proche-Orient, la colombe blanche ?tait associ?e aux d?esses de l?amour. A cause de son comportement et aussi de sa dimension ? a?rienne ?, cet oiseau a sembl? pouvoir symboliser en m?me temps l?amour terrestre et l?existence spirituelle et c?leste.', 8),
(31, 'SAINT ESPRIT', 'Dans le Cantique des cantiques, la communaut? bien-aim?e de Dieu est appel?e ? ma colombe ?, et, progressivement, on en est venu ? consid?rer que la l?g?ret? de cet animal repr?sentait ce que l?homme avait en lui d?imp?rissable: son ?me. Le psalmiste ne s??crie-t-il pas: ? Ne livre pas ? la b?te l??me de ta colombe! ? (psaume 74,19). Dans la tradition chr?tienne, on va s?appuyer sur l?analogie faite par l?Evangile lui-m?me, et on va consid?rer que la colombe peut ?voquer ? l?Ame de Dieu ?. Mais l?Esprit Saint, bien entendu, n?est pas une colombe !', 9),
(32, 'SAINT ESPRIT', 'Pont-Saint-Esprit est une commune fran?aise situ?e dans le d?partement du Gard, en r?gion Languedoc-Roussillon.\r\n\r\nSes habitants et habitantes sont les Spiripontains.Un pont audacieux lanc? sur le Rh?ne au Moyen ?ge, un peu en aval du confluent avec l''Ard?che, a favoris? l''?closion de cette petite cit?.\r\n\r\nLa ville de Pont-Saint-Esprit est situ?e la rive droite du Rh?ne au confluent de l''Ard?che et du Rh?ne ? la fronti?re imm?diate de trois d?partements : outre le Gard, l''Ard?che ? l''ouest et le Vaucluse ? l''est. Ceci, sans m?me compter la Dr?me dont le territoire vient l?cher ? quelques kilom?tres pr?s le d?partement du Gard.\r\n\r\nPont-Saint-Esprit est ainsi au carrefour strat?gique de trois r?gions : Rh?ne-Alpes, Languedoc-Roussillon et Provence-Alpes-C?te d''Azur. Preuve de son importance tant strat?gique que religieuse, Pont-Saint-Esprit rec?le encore de nombreux ?difices religieux et civils dignes d''int?r?t bien que n?cessitant d''importantes campagnes de restauration.', 10);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `categorie`
--
ALTER TABLE `categorie`
 ADD PRIMARY KEY (`nom`), ADD UNIQUE KEY `nom` (`nom`,`parent`), ADD KEY `id_categorie` (`parent`);

--
-- Index pour la table `niveau`
--
ALTER TABLE `niveau`
 ADD PRIMARY KEY (`nom`), ADD KEY `id_niveau` (`categorie`);

--
-- Index pour la table `paragraphe`
--
ALTER TABLE `paragraphe`
 ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `niveau` (`niveau`,`position`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `paragraphe`
--
ALTER TABLE `paragraphe`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=33;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `categorie`
--
ALTER TABLE `categorie`
ADD CONSTRAINT `id_categorie` FOREIGN KEY (`parent`) REFERENCES `categorie` (`nom`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `niveau`
--
ALTER TABLE `niveau`
ADD CONSTRAINT `id_niveau` FOREIGN KEY (`categorie`) REFERENCES `categorie` (`nom`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `paragraphe`
--
ALTER TABLE `paragraphe`
ADD CONSTRAINT `id_paragraphe` FOREIGN KEY (`niveau`) REFERENCES `niveau` (`nom`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
