using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public int ObjectSpawned = 0;
    public int ObjectsDestroyed = 0;
    public int SpawnNumber;
    public int MaxBalloons = 40;
    public int BalloonArmor = 1;
    public int Gamelevel = 1;

    public float FloatStrength = 30f;
    public float FlightSpeed = 200f;
    public float SpawnTime = 0;

    public bool BalloonDestroyed = false;
    public bool BalloonPenetration = false;
    public bool MayhemMode = false;

    public void setGamelevel(int Gamelevel)
    {
        this.Gamelevel = Gamelevel;
    }
    public int getGamelevel()
    {
        return Gamelevel;
    }
    public void setSpawnNumber(int SpawnNumber)
    {
        this.SpawnNumber = SpawnNumber;
    }
    public int getSpawnNumber()
    {
        return SpawnNumber;
    }
    public void ObjectSpawnedCounter()
    {
        ObjectSpawned++;
    }
    public int getObjectSpawnedCount()
    {
        return ObjectSpawned;
    }
    public int getObjectsDestroyed()
    {
        return ObjectsDestroyed;
    }
    public void setBalloonDestroyedTrue()
    {
        ObjectsDestroyed++;
        this.BalloonDestroyed = true;
    }
    public bool getBalloonDestroyed()
    {
        return BalloonDestroyed;
    }
    public void setBalloonDestroyedFalse()
    {
        this.BalloonDestroyed = false;
    }
    public void setBalloonPenetration()
    {
        this.BalloonPenetration = true;
    }
    public bool getBalloonPenetration()
    {
        return BalloonPenetration;
    }
    public void setSpawnTime(float newSpawnTime)
    {
        this.SpawnTime = newSpawnTime;
    }
    public float getSpawnTime()
    {
        return SpawnTime;
    }
    public void setBalloonDifficulty(int Balloonlv)
    {
        this.BalloonArmor = Balloonlv;
    }
    public int getBalloonDifficulty()
    {
        return BalloonArmor;
    }
    public void setFloatStrength(float FloatStrength)
    {
        this.FloatStrength = FloatStrength;
    }
    public float getFloatStrength()
    {
        return this.FloatStrength;
    }
    public void setMaxBalloons(int MaxBalloons)
    {
        this.MaxBalloons = MaxBalloons;
    }
    public int getMaxBalloons()
    {
        return MaxBalloons;
    }
    public void SetMayhemGameModeTrue()
    {
        MayhemMode = true;
    }
    public bool GetMayhemGameMode()
    {
        return MayhemMode;
    }
    public void setFlightSpeed(float FlightSpeed)
    {
        this.FlightSpeed = FlightSpeed;
    }
    public float getFlightSpeed()
    {
        return this.FlightSpeed;
    }
}
