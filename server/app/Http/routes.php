<?php

/*
|--------------------------------------------------------------------------
| Application Routes
|--------------------------------------------------------------------------
|
| Here is where you can register all of the routes for an application.
| It's a breeze. Simply tell Laravel the URIs it should respond to
| and give it the controller to call when that URI is requested.
|
*/

Route::get('/', 'WelcomeController@index');

Route::get('home', 'HomeController@index');

Route::controllers([
                       'auth'     => 'Auth\AuthController',
                       'password' => 'Auth\PasswordController',
                   ]);

Route::group(
    [
        'prefix' => 'api',
    ],
    function()
    {
        Route::get('status', function()
        {
            return Response::json(
                [
                    "status" => "ok",
                ]
            );
        });

        Route::resource('gameplay', 'GameplayController');
        Route::resource('ruleset', 'RulesetController');
        Route::resource('rule', 'RuleController');
        Route::resource('card', 'CardController');
    }
);
