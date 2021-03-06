%% Difficulty model
N = 100;
x = linspace(0, 1.2, N);

y = 1.2 - x .^ 3;

figure, clf, 
plot(4 - x .* 5, y, 'LineWidth', 2);
grid on, grid minor, 
xlabel('Rank');
ylabel('Adjusted Factor');
title('Relationship of Players Skill and Adjusted Factor');
axis([0, 4, 0.6, 1.2]);