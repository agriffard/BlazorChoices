# PRD — Composant Blazor pour Choices.js

## 1. Contexte & Objectif

Ce document décrit les exigences produit (PRD) pour un composant Blazor encapsulant le plugin JavaScript Choices.js v11.2.0.
L’objectif est de fournir un composant Blazor réutilisable pour remplacer les éléments <select> et <input> standards
par une interface riche, configurable et accessible.

Le projet inclut :
- Un composant Blazor réutilisable
- Une application Blazor WebAssembly de démonstration
- Un déploiement fonctionnel sur GitHub Pages

## 2. Références

- Choices.js : https://github.com/Choices-js/Choices
- Démo officielle : https://choices-js.github.io/Choices/
- Blazor WebAssembly : https://learn.microsoft.com/aspnet/core/blazor

## 3. Public Cible

- Développeurs .NET / Blazor
- Équipes frontend souhaitant une alternative moderne aux selects HTML
- Mainteneurs de librairies UI Blazor

## 4. Portée Fonctionnelle

### 4.1 Composants

#### ChoicesSelect
- Encapsulation d’un élément <select>
- Support simple et multiple
- Recherche intégrée
- Placeholder configurable
- Gestion des valeurs sélectionnées
- Binding Blazor (EventCallback)

#### ChoicesInput
- Encapsulation d’un <input>
- Support des tags
- Ajout / suppression dynamique
- Limitation du nombre d’éléments

### 4.2 Options supportées

- searchEnabled
- removeItemButton
- shouldSort
- placeholderValue
- maxItemCount
- duplicateItemsAllowed

Les options doivent être exposées via un objet C# sérialisé vers JavaScript.

## 5. Architecture Technique

- Blazor WebAssembly
- JavaScript Interop (IJSRuntime)
- Chargement statique de choices.min.js et choices.min.css
- slnx pour le fichier de solution
- Aucune dépendance serveur
- .NET 10

## 6. API Publique (C#)

- InitAsync()
- DestroyAsync()
- SetValueAsync(...)
- GetValueAsync()

Événements :
- OnChange (single)
- OnChangeMultiple (multi)
- OnTagsChanged

## 7. Exigences Non Fonctionnelles

- Compatible navigateurs modernes
- Pas de fuite mémoire JS
- Destruction propre des instances Choices
- Performances acceptables avec listes > 1 000 items

## 8. Sample

Le sample doit inclure :
- Select simple
- Select multiple
- Input avec tags
- Exemple avec données dynamiques
- Code Blazor visible (ou documenté)

## 9. Déploiement GitHub Pages

- Build en mode Release
- BaseHref configuré pour GitHub Pages
- Publication via branche gh-pages
- Démo accessible publiquement

## 10. Livrables

- PRD.md
- Code source du composant
- Application Blazor WASM de démonstration
- README.md
- Site GitHub Pages fonctionnel
