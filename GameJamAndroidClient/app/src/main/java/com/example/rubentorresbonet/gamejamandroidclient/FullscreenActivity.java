package com.example.rubentorresbonet.gamejamandroidclient;

import com.example.rubentorresbonet.gamejamandroidclient.util.SystemUiHider;

import android.annotation.TargetApi;
import android.app.Activity;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.nio.ByteBuffer;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Random;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.LinkedBlockingQueue;

/**
 * An example full-screen activity that shows and hides the system UI (i.e.
 * status bar and navigation/system bar) with user interaction.
 *
 * @see SystemUiHider
 */
public class FullscreenActivity extends Activity {
    private final int UDP_PORT = 8085;
    private final String UDP_HOST = "172.16.15.177";
    private LinkedBlockingQueue<Packet> packetsQueue = new LinkedBlockingQueue<Packet>();
    private final long PACKET_INTERVAL_MS = 100;

    private int playerId = 0;
    private String playerName = "RBN";

    public enum ACTION {
        RIGHT_UP,
        UP,
        LEFT_UP,
        RIGHT,
        MIDDLE,
        LEFT,
        LEFT_DOWN,
        DOWN,
        RIGHT_DOWN,
        ATTACK
    };

    class Packet
    {
        public byte[] content;
        public Packet(int playerId, String playerName, ACTION action) {
            while (playerName.length() < 3) {
                playerName += "?";
            }
            if (playerName.length() > 3) {
                Log.e("RBN", "PlayerName wrong length");
                return;
            }
            try {
                byte actionByte = (byte)action.ordinal();
                byte[] playerNameBytes = playerName.getBytes("US-ASCII");
                content = ByteBuffer.allocate(8).
                        putInt(playerId).
                        put(playerNameBytes).
                        put(actionByte).
                        array();
            } catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            }

        }
    }

    class NetworkingThread extends Thread
    {
        public void run() {
            InetAddress local = null;
            DatagramSocket datagramSocket = null;
            try {
                local = InetAddress.getByName(UDP_HOST);
                datagramSocket = new DatagramSocket();
            } catch (UnknownHostException e) {
                e.printStackTrace();
                return;
            } catch (SocketException e) {
                e.printStackTrace();
            }
            while (true) {
                try {
                    Packet packet = packetsQueue.take();
                    DatagramPacket diagramPacket = new DatagramPacket(packet.content, packet.content.length, local, UDP_PORT);
                    datagramSocket.send(diagramPacket);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                } catch (UnknownHostException e) {
                    e.printStackTrace();
                } catch (SocketException e) {
                    e.printStackTrace();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    };


    long lastPacketMs = 0;
    int lastDirection = -1;

    private ACTION directionToAction(int direction) {
        switch (direction) {
            case JoystickView.FRONT:
                return ACTION.UP;

            case JoystickView.FRONT_RIGHT:
                return ACTION.LEFT_UP;

            case JoystickView.RIGHT:
                return ACTION.LEFT;

            case JoystickView.RIGHT_BOTTOM:
                return ACTION.RIGHT_DOWN;

            case JoystickView.BOTTOM:
                return ACTION.DOWN;

            case JoystickView.BOTTOM_LEFT:
                return ACTION.LEFT_DOWN;

            case JoystickView.LEFT:
                return ACTION.RIGHT;

            case JoystickView.LEFT_FRONT:
                return ACTION.RIGHT_UP;
            default:
                return ACTION.MIDDLE;
        }
    }

    private void sendPacket(int direction) {
        if (direction != lastDirection) {
            lastDirection = direction;
            lastPacketMs = 0;
        }
        long currentMs = System.currentTimeMillis();

        if (lastPacketMs + PACKET_INTERVAL_MS  <= currentMs) {
            lastPacketMs = currentMs;
            ACTION action = directionToAction(direction);
            Packet packet = new Packet(playerId, playerName, action);
            packetsQueue.add(packet);
        }
    }


    private JoystickView joystick;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_fullscreen);

        Random random = new Random();
        playerId = random.nextInt(2000000000);

        NetworkingThread networkingThread = new NetworkingThread();
        networkingThread.start();

        joystick = (JoystickView) findViewById(R.id.joystickView);

        joystick.setOnJoystickMoveListener(new JoystickView.OnJoystickMoveListener() {

            @Override
            public void onValueChanged(int angle, int power, int direction) {
                sendPacket(direction);
            }
        }, JoystickView.DEFAULT_LOOP_INTERVAL);

        findViewById(R.id.attackButton).setOnTouchListener(attachTouchListener);
    }

    @Override
    protected void onPostCreate(Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);
    }

    View.OnTouchListener attachTouchListener = new View.OnTouchListener() {
        @Override
        public boolean onTouch(View view, MotionEvent motionEvent) {
            if (motionEvent.getAction() == android.view.MotionEvent.ACTION_UP) {
                Packet packet = new Packet(playerId, playerName, ACTION.ATTACK);
                packetsQueue.add(packet);
            }


            return false;
        }
    };

    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if (hasFocus) {
            final View decorView = getWindow().getDecorView();
            decorView.setSystemUiVisibility(
                    View.SYSTEM_UI_FLAG_LAYOUT_STABLE
                            | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
                            | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                            | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
                            | View.SYSTEM_UI_FLAG_FULLSCREEN
                            | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY);}
    }
}
