[![build](https://github.com/Mascavidrio/KeePassDPG/actions/workflows/build.yml/badge.svg)](https://github.com/Mascavidrio/KeePassDPG/actions/workflows/build.yml)

# KeePassDPG
A plugin for KeePass to allow creating easy to remember passwords based on a word dictionary.

## Features
 * Create passwords using an internal dictionary file of words ranging from 6 to 28 characters in length with the exception of words with 26 characters. There is no dictionary for this option.
 * Allow custom character substitution by specifying a substitution list.
     * For example, substitute the letter A for 4 or @, substitute the letter O for 0, etc.
 * Allow first letter, random letter, or no capitalization.

## System Requirements
 * KeePass 2.50 or higher

## Windows Installation
 1. Download latest release from [https://github.com/Mascavidrio/KeePassDPG/releases](https://github.com/Mascavidrio/KeePassDPG/releases).
 2. Copy plgx directly into the Plugins directory under the KeePass directory.
 3. Start KeePass.

## Using KeePassDPG
 1. In KeePass open the Password Generator from Tools > Generate Password... or from the Add Entry or Edit Entry windows.
 2. Click on the Generate using custom algorithm radio button and select KeePassDPG from the dropdown.
 3. Click OK to select the generated password.

### Generator Options

Click on the button next to the custom algorithm dropdown in the Password Generator window to bring up the Dictionary Password Generator Options window.

#### Dictionary

This tab is used to specify the word dictionary to use. The generator uses several dictionary files, one for each word length to randomly select a word.

#### Substitution

This tab is used to specify whether the generator uses a character substitution scheme. Click on the checkbox to enable character substitution and select one of tbe built in lists or specify your own. Subsitution rules can be specified by indicating which character can be substituted by another. For example: to substitute all s with $ enter s=$. To specify multiple character substitutions separate each substitution by a semicolon. For example: a=4;s=$.

#### Capitalization

This tab is used to specify capitalization and whether or not the generator capitalizes the first letter or random letters. Select None to disable capitalization. Select First Letter to capitalize only the first letter in the password. Select Random to have the generator capitalize random letters in the password.

## Security and Disclaimer

I'm not a security expert and I don't claim that the passwords generated by this plugin are in any way more secure than other methods. The passwords are generated using a dictionary of words of certain lengths which can easily be guessed. By adding character substitution and capitalization to the generator, the plugin is able to generate passwords that are easy to remember and that also follow some basic password security guidelines. For example, by specifying capitalization and character substitution, the plugin can generat passwords such as b10$T@t1$t1c1@n$ (biostatisticians) which may be easier to remember but harder to guess. Use these passwords at your own risk.