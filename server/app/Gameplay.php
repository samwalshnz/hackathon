<?php namespace App;

use Illuminate\Database\Eloquent\Model;

/**
 * Class Gameplay
 *
 * @package App
 *
 * @property string  code
 * @property Ruleset ruleset
 * @property User    turn
 * @property User    created_at
 * @property User    updated_at
 */
class Gameplay extends Model {

    /**
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
     */
    public function ruleset()
    {
        return $this->belongsTo(Ruleset::class);
    }

    /**
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
     */
    public function turn()
    {
        return $this->belongsTo(User::class, 'turn_id');
    }
}
