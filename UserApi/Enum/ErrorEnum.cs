﻿using System.ComponentModel;

namespace UserApi.Enum;

public enum ErrorEnum
{
    //Global
    [Description("Vous n'avez pas les droits nécessaire")]
    Sup401Authorization,
    [Description("Erreur inconnu")]
    Sup500UnknownError,
    [Description("Aucune description pour cette erreur")]
    Sup500NoErrorDescription,
    [Description("Vous n'êtes pas authorisée")]
    Sup401NotConnected,
    
    //User
    [Description("Utilisateur Introuvable")]
    Sup404UserNotFound,
    [Description("Email déjà pris")]
    Sup401EmailTaken,
    [Description("L'email est trop long et ne doit pas faire plus de 100 caractères")]
    Sup400TooLongEmail,
    [Description("L'email ne correspond pas aux exisences")]
    Sup400EmailNotAccepted,
    [Description("Le prénom est trop long et ne doit pas faire plus de 100 caractères")]
    Sup400TooLongFirstname,
    [Description("Le nom est trop long et ne doit pas faire plus de 100 caractères")]
    Sup400TooLongLastname,
    [Description("Le mot de passe ne peux pas faire plus de 255 caractères")]
    Sup400TooLongPassword,
    [Description("Le mot de passe n'est pas au bon format, il faut au moins 1 minuscule, 1 majuscule, 1 chiffres et 1 caractère spécial")]
    Sup400PasswordFormat,
    [Description("Le mot de passe doit faire au moins 8 caractères")]
    Sup400TooShortPassword,
    [Description("Le mot de passe ou l'email est incorrecte")]
    Sup401WrongCredential,
}