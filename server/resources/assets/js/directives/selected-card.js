/*globals angular*/
'use strict';

angular.module('CircleOfDeath.directives').directive('selectedCard', function() {
    return {
        replace: true,
        restrict: 'E',
        templateUrl: 'selected-card.html'
    };
});
