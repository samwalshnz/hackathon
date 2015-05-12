# hackathon

[![Join the chat at https://gitter.im/aklhackathon/hackathon](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/aklhackathon/hackathon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/samwalshnz/hackathon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

^^ Click this link above to enter the hackathon chat room

## What are we building?
A Really simple cheat sheet on the web / mobile. It will be fully responsive so the cheat sheet will be available for everyone to use as reference during the game.

## How is this useful?
Because everyone has their own variation of rules to the game. So, to avoid any drunk conflicts mid-game, it's good to set out the basic rules for everyone on the big screen / their own screen before the game has even started.

## How does the user use this?
Simply use this as the cheatsheet for the game whenever there are doubts about the game rules.

#### Default view (Web)
![Default View](http://i.imgur.com/6AITbFw.png?1 "Default View")
By default, the user will see the grid view of all 14 cards, with their respective rule name displayed for quick reminder without going into the rule description view

#### Rule description view (Web)
![Description](http://i.imgur.com/OqT2Csp.png?1 "Description View")
If the name wasn't explanatory enough, users can click the card to see the full description of the rule. 

Perhaps this state can also be navigated left and right to other cards, instead always going back to the grid view first in order to view other cards.

If the user wants to edit the rule, they can click the little "Edit" button link on the top right corner.

#### Rule edit view (Web)
![Description](http://i.imgur.com/SkNWtTQ.png?1 "Rule Edit View")
In here users can edit the `name` and `rules` properties of this card. They can also add several rules if they want.

## Running the FE Client
If you don't have gulp or bower installed globally run:
`npm install -g gulp && npm install -g bower`

Then cd into the `server` dir and run:
`npm install && bower install`

To run the client locally in the `server` dir run:
`gulp serve`
This will start a watcher on your dev files, auto-reload on change and serve your files on a simple http server.

Access the app at [localhost:9000/app.html](localhost:9000/app.html) in your browser.

## Drink responsibly and peacefully.
![drink-happy](http://i.giphy.com/DfLwM9kttDFEQ.gif "Drink responsibly and peacefully")
